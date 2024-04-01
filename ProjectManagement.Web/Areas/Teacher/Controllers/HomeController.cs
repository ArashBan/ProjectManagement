using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Web.PresentationExtensions;

namespace ProjectManagement.Web.Areas.Teacher.Controllers
{
    public class HomeController : TeacherBaseController
    {
        private readonly INewsService _newsService;
        private readonly IProfileService _profileService;

        public HomeController(IProfileService profileService, INewsService newsService)
        {
            _profileService = profileService;
            _newsService = newsService;
        }


        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account");
            if (User.IsStudent()) return Redirect("/");

            ViewData["Profile"] = await _profileService.GetTeacherProfile(User.GetUserId());
            ViewData["News"] = await _newsService.GetLastFive();
            return View();
        }
    }
}
