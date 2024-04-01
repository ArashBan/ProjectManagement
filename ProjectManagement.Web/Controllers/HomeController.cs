using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Web.PresentationExtensions;

namespace ProjectManagement.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly INewsService _newsService;
        private readonly IProfileService _profileService;
        private readonly INotificationService _notificationService;

        public HomeController(INotificationService notificationService, IProfileService profileService, INewsService newsService)
        {
            _newsService = newsService;
            _profileService = profileService;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Login", "Account");
            if (!User.IsStudent()) return Redirect("/teacher");

            ViewData["Profile"] = await _profileService.GetStudentProfile(User.GetUserId());
            ViewData["News"] = await _newsService.GetLastFive();
            return View();
        }

        [HttpGet("project-details")]
        public async Task<IActionResult> ProjectDetails()
        {
            ViewData["Profile"] = await _profileService.GetStudentProfile(User.GetUserId());
            ViewData["News"] = await _newsService.GetLastFive();
            return View();
        }  
        
        [HttpGet("internship-details")]
        public async Task<IActionResult> InternshipDetails()
        {
            ViewData["Profile"] = await _profileService.GetStudentProfile(User.GetUserId());
            ViewData["News"] = await _newsService.GetLastFive();
            return View();
        }

        public async Task<IActionResult> Notifications()
        {
            ViewData["Notifications"] = await _notificationService.GetNotifications(User.GetUserId());
            await _notificationService.ReadAll(User.GetUserId());
            return View();
        }
    }
}