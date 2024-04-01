using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.DataLayer.DTOs.Course;
using ProjectManagement.Web.PresentationExtensions;

namespace ProjectManagement.Web.Controllers
{
    public class InternshipController : BaseController
    {
        private readonly IStudentService _studentService;
        private readonly IInternshipService _internshipService;

        public InternshipController(IInternshipService internshipService, IStudentService studentService)
        {
            _studentService = studentService;
            _internshipService = internshipService;
        }

        #region Request internship

        [HttpGet("request-internship")]
        public async Task<IActionResult> RequestInternship()
        {
            TempData["SuccessMessage"] = null;
            return View();
        }

        [HttpPost("request-internship"), ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestInternship(InternshipDto internship)
        {
            if (ModelState.IsValid)
            {
                if (internship.AnyDaySelected())
                {
                    internship.StudentId = User.GetId();
                    var result = await _internshipService.RequestInternship(internship);
                    if (result.IsSucceed)
                        TempData["SuccessMessage"] = "درخواست شما با موفقیت ثبت شد. در بخش پیگیری می تونید وضعیت آن را بررسی کنید.";
                    else
                        TempData["ErrorMessage"] = result.Message;

                    return RedirectToAction("ListOfRequests", "Internship");
                }
                else
                    TempData["ErrorMessage"] = "حداقل یکی از روهای هفته را باید انتخاب کنید";
            }

            return View(internship);
        }

        [HttpGet("internship-requests")]
        public async Task<IActionResult> ListOfRequests()
        {
            ViewData["Internships"] = await _studentService.GetStudentsInternshipRequests(User.GetId());
            return View();
        }

        #endregion

        #region Internship report

        [HttpGet("send-internship-report")]
        public async Task<IActionResult> SendInternshipReport()
        {
            var report = new InternshipReportDto
            {
                DaysOfAttendance = await _internshipService
                .GetAttendanceDaysByStudentId(User.GetId())
            };
            ViewData["Report"] = report;
            return View();
        }

        [HttpPost("send-internship-report"), ValidateAntiForgeryToken]
        public async Task<IActionResult> SendInternshipReport(InternshipReportDto report)
        {
            if (ModelState.IsValid)
            {
                await _internshipService.SendWeeklyReport(report, User.GetId());

                return RedirectToAction("SendInternshipReport", "Internship");
            }

            report.DaysOfAttendance = await _internshipService
                .GetAttendanceDaysByStudentId(User.GetId());

            ViewData["Report"] = report;
            return View(report);
        }

        [HttpGet("internship-reports")]
        public async Task<IActionResult> ShowInternshipReports()
        {
            ViewData["Reports"] = await _internshipService.GetInternshipReportsList(User.GetId());

            return View();
        }

        #endregion
    }
}
