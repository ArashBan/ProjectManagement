using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Application.Extensions;
using ProjectManagement.DataLayer.DTOs.Account;
using Newtonsoft.Json;
using ProjectManagement.Web.PresentationExtensions;

namespace ProjectManagement.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;

        public AccountController(IStudentService studentService, ITeacherService teacherService, IUserService userService)
        {
            _userService = userService;
            _teacherService = teacherService;
            _studentService = studentService;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUser login)
        {
            if (ModelState.IsValid)
            {
                login.IsStudent = login.Username.AnyDigit();
                var user = await _userService.GetUserForLogin(login);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                          new Claim(ClaimTypes.Name, user.FullName),
                          new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                          new Claim("PersonId", user.Id.ToString()),
                          new Claim("IsStudent", user.IsStudent.ToString()),
                          new Claim("StudentCode", user.StudentCode == null ? "" : user.StudentCode),
                          new Claim("NationalCode", user.NationalCode),
                          new Claim("IsParent", user.IsParent.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };

                    await HttpContext.SignInAsync(principal, properties);

                    TempData["SuccessMessage"] = "عملیات ورود با موفقیت انجام شد";
                    return login.IsStudent ? Redirect("/") : Redirect("/teacher");
                }
                else
                {                    
                    TempData["ErrorMessage"] = "کاربر مورد نظر یافت نشد";
                    return View(login);
                }
            }
            else
            {
                TempData["ErrorMessage"] = "نام کاربری یا کلمه عبور خالی می باشد.";
            }

            return View(login);
        }


        [HttpGet("log-out")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
