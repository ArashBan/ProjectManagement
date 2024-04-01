using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.Web.PresentationExtensions;

namespace ProjectManagement.Web.Areas.Teacher.Controllers
{
    public class NewsController : TeacherBaseController
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("add-news")]
        public async Task<IActionResult> AddNews()
        {
            TempData["SuccessMessage"] = null;
            return View();
        }

        [HttpPost("add-news"), ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNews(NewsDto news)
        {
            if (ModelState.IsValid)
            {
                news.TeacherId = User.GetId();
                await _newsService.AddNews(news);

                return RedirectToAction("AddNews");
            }

            return View(news);
        }


        [HttpGet("news-list")]
        public async Task<IActionResult> NewsList()
        {
            ViewData["News"] = await _newsService.GetAllNews();
            return View();
        }

        [HttpPost("news-list/{newsId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> NewsList(int newsId)
        {
            await _newsService.DeleteNews(newsId);
            return RedirectToAction("ReloadNewsList");
        }

        [HttpGet("news-list-updated")]
        public IActionResult ReloadNewsList()
        {
            return RedirectToAction("NewsList");
        }
    }
}