using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Services.Implementations;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.DataLayer.DTOs.Course;
using ProjectManagement.DataLayer.Entities.Courses;
using ProjectManagement.Web.PresentationExtensions;

namespace ProjectManagement.Web.Areas.Teacher.Controllers
{
    public class InternshipController : TeacherBaseController
    {
        private readonly ITeacherService _teacherService;
        private readonly IInternshipService _internshipService;

        public InternshipController(ITeacherService teacherService, IInternshipService internshipService)
        {
            _teacherService = teacherService;
            _internshipService = internshipService;
        }


        #region Internship Request

        [HttpGet("internship-requests-list-updated")]
        public async Task<IActionResult> ReloadRequests()
        {
            ViewData["Projects"] = await _teacherService.GetProjectRequests(User.GetId());
            return RedirectToAction("ListOfRequests", "Internship");
        }

        [HttpGet("internship-requests-list")]
        public async Task<IActionResult> ListOfRequests()
        {
            var teacherId = User.GetId();
            ViewData["IsParent"] = await _teacherService.CheckIfParent(teacherId);
            ViewData["Projects"] = await _teacherService.GetInternshipRequests(teacherId);
            return View();
        }

        [HttpPost("internship-requests-list/{projectRequestId}/{situation}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ListOfRequests(int projectRequestId, AcceptSituation situation, string feedback)
        {
            await _teacherService.ChangeInternshipRequestSituation(situation, feedback, projectRequestId, User.GetId());
            return RedirectToAction("ReloadRequests", "Internship");
        }

        #endregion

        #region Internship report

        [HttpGet("internship-reports-list")]
        public async Task<IActionResult> InternshipReportsList()
        {
            ViewData["Reports"] = await _teacherService.GetInternshipReportList(User.GetId());
            var report = new InternshipReportDto
            {
                DaysOfAttendance = await _internshipService
               .GetAttendanceDaysByStudentId(User.GetId())
            };

            ViewData["Report"] = report;
            return View();
        }

        [HttpPost("internship-reports-list/{internshipReportId}")]
        public async Task<IActionResult> InternshipReportsList(int internshipReportId, string feedback)
        {
            await _teacherService.ReadInternshipReport(internshipReportId, feedback);
            return RedirectToAction("ReloadReports", "Internship");
        }

        [HttpGet("reports-list-reload")]
        public async Task<IActionResult> ReloadReports()
        {
            ViewData["Reports"] = await _teacherService.GetProjectProgressList(User.GetId());
            return RedirectToAction("InternshipReportsList");
        }

        #endregion        
    }
}
