using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.DataLayer.DTOs.Course;
using ProjectManagement.Web.PresentationExtensions;

namespace ProjectManagement.Web.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;

        public ProjectController(ICourseService courseService, IStudentService studentService)
        {
            _courseService = courseService;
            _studentService = studentService;
        }

        #region Request Project

        [HttpGet("request-project")]
        public IActionResult RequestProject()
        {
            TempData["SuccessMessage"] = null;
            return View();
        }

        [HttpPost("request-project")]
        public async Task<IActionResult> RequestProject(RequestProjectDto project)
        {
            if (ModelState.IsValid)
            {
                project.StudentId = User.GetId();
                var result = await _courseService.RequestProject(project);
                if (result.IsSucceed)
                    TempData["SuccessMessage"] = "درخواست شما با موفقیت ثبت شد. در بخش پیگیری می تونید وضعیت آن را بررسی کنید.";
                else
                    TempData["ErrorMessage"] = result.Message;

                return RedirectToAction("ListOfRequests", "Project");
            }

            return View(project);
        }


        [HttpGet("project-requests")]
        public async Task<IActionResult> ListOfRequests()
        {
            ViewData["Projects"] = await _studentService.GetStudentsProjectRequests(User.GetId());
            return View();
        }

        #endregion

        #region Project Progress

        [HttpGet("send-project-progress")]
        public async Task<IActionResult> SendProjectProgress()
        {
            TempData["SuccessMessage"] = null;
            return View();
        }

        [HttpPost("send-project-progress")]
        public async Task<IActionResult> SendProjectProgress(ProjectProgressDto progress)
        {
            if (ModelState.IsValid)
            {
                await _courseService.AddProjectProgress(progress, User.GetId());
                TempData["SuccessMessage"] = "گزارش شما با موفقیت ارسال شد.";

                return RedirectToAction("ShowProjectProgresses", "Project");
            }

            return View(progress);
        }


        [HttpGet("project-progresses")]
        public async Task<IActionResult> ShowProjectProgresses()
        {
            ViewData["Progresses"] = await _courseService.GetProjectProgressList(User.GetId());

            return View();
        }

        #endregion

        #region Project Steps

        [HttpGet("project-steps")]
        public async Task<IActionResult> ViewProjectSteps()
        {
            ViewData["Project"] = await _courseService.GetConfirmedProjectByStudentId(User.GetId());
            return View();
        }

        #endregion

        #region Project Defense

        [HttpGet("request-defense")]
        public async Task<IActionResult> RequestProjectDefense()
        {
            var project = await _courseService.GetConfirmedProjectByStudentId(User.GetId());
            if (project != null)
                ViewData["Project"] = project;

            return View();
        }

        [HttpPost("request-defense")]
        public async Task<IActionResult> RequestProjectDefense(ProjectDefenseRequestDto defenseRequest)
        {
            var result = await _courseService.RequestProjectDefense(defenseRequest);
            return View();
        }

        [HttpGet("project-defense-list")]
        public async Task<IActionResult> ListOfProjectDefenseRequests()
        {
            var res = await _courseService.GetProjectDefenseRequestListByStudentId(User.GetId());
            ViewData["DefenseList"] = res;
            return View();
        }

        #endregion
    }
}
