using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Web.PresentationExtensions;

namespace ProjectManagement.Web.Controllers
{
    public class HelpController : BaseController
    {
        private readonly IProblemService _problemService;

        public HelpController(IProblemService problemService)
        {
            _problemService = problemService;
        }


        [HttpGet("frequently-questions")]
        public async Task<IActionResult> FrequentlyQuestions()
        {
            ViewData["Questions"] = await _problemService.GetQuestionsList();
            return View();
        }
    }
}