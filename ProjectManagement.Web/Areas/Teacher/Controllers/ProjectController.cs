using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.DataLayer.DTOs.Course;
using ProjectManagement.DataLayer.Entities.Courses;
using ProjectManagement.Web.PresentationExtensions;

namespace ProjectManagement.Web.Areas.Teacher.Controllers
{
    public class ProjectController : TeacherBaseController
    {
        private readonly ITeacherService _teacherService;

        public ProjectController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }


        #region Project Request

        [HttpGet("requests-list-updated")]
        public async Task<IActionResult> ReloadRequests()
        {
            ViewData["Projects"] = await _teacherService.GetProjectRequests(User.GetId());
            return RedirectToAction("ListOfRequests", "Project");
        }

        [HttpGet("requests-list")]
        public async Task<IActionResult> ListOfRequests()
        {
            var teacherId = User.GetId();
            ViewData["IsParent"] = await _teacherService.CheckIfParent(teacherId);
            ViewData["Projects"] = await _teacherService.GetProjectRequests(teacherId);
            return View();
        }

        [HttpPost("requests-list/{projectRequestId}/{situation}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ListOfRequests(int projectRequestId, AcceptSituation situation, string feedback)
        {
            await _teacherService.ChangeProjectRequestSituation(situation, feedback, projectRequestId, User.GetId());
            return RedirectToAction("ReloadRequests", "Project");
        }

        #endregion

        #region Project Progress

        [HttpGet("project-progresses-list")]
        public async Task<IActionResult> ProjectProgressesList()
        {
            ViewData["Progresses"] = await _teacherService.GetProjectProgressList(User.GetId());
            return View();
        }

        [HttpPost("project-progress-list/{projectProgressId}")]
        public async Task<IActionResult> ProjectProgressesList(int projectProgressId, string feedback)
        {
            await _teacherService.ReadProjectProgress(projectProgressId, feedback);
            return RedirectToAction("ReloadProgress", "Project");
        }

        [HttpGet("progress-list-reload")]
        public async Task<IActionResult> ReloadProgress()
        {
            ViewData["Progresses"] = await _teacherService.GetProjectProgressList(User.GetId());
            return RedirectToAction("ProjectProgressesList");
        }

        #endregion

        #region Project defense requests

        [HttpGet("defense-requests")]
        public async Task<IActionResult> DefenseRequests()
        {
            ViewData["Requests"] = await _teacherService.GetTeacherDefenseRequests(User.GetId());
            return View();
        }

        [HttpPost("defense-requests/{defenseRequestId}/{situation}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DefenseRequests(int defenseRequestId, AcceptSituation situation, ProjectDefenseRequestDto defenseRequest)
        {
            if (ModelState.IsValid)
            {
                defenseRequest.Situation = situation;
                defenseRequest.DefenseRequestId = defenseRequestId;
                defenseRequest.StudentUserId = User.GetUserId();
                await _teacherService.ChangeDefenseState(defenseRequest, defenseRequestId);
            }

            return View();
        }

        #endregion
    }
}
