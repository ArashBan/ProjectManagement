using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.DataLayer.DTOs.Common;

namespace ProjectManagement.Application.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;             
        private readonly IInternshipService _internshipService;

        public ProfileService(ICourseService courseService, IStudentService studentService, IInternshipService internshipService, ITeacherService teacherService)
        {
            _courseService = courseService;
            _studentService = studentService;
            _teacherService = teacherService;
            _internshipService = internshipService;
        }


        public async Task<StudentProfileDto> GetStudentProfile(int userId)
        {            
            var student = await _studentService.GetStudentByUserId(userId);
            var project = await _courseService.GetConfirmedProjectByStudentId(student.Id);
            var internship = await _internshipService.GetConfirmedInternshipByStudentId(student.Id);
            var progressess = await _courseService.GetProjectProgressList(student.Id);
            var reports = await _internshipService.GetInternshipReportsList(student.Id);

            return new StudentProfileDto
            {
                Student = student,
                Project = project,
                Internship = internship,
                InternshipReports = reports,
                ProjectProgresses = progressess
            };
        }

        public async ValueTask DisposeAsync()
        {
            if (_courseService != null)
                await _courseService.DisposeAsync();
            if (_internshipService != null)
                await _internshipService.DisposeAsync();
            if (_studentService != null)
                await _studentService.DisposeAsync();
        }

        public async Task<TeacherProfileDto> GetTeacherProfile(int userId)
        {
            var teacher = await _teacherService.GetTeacherByUserId(userId);
            var stats = await _teacherService.GetTeacherStatsByTeacherId(teacher.Id);

            return new TeacherProfileDto
            {
                Teacher = teacher,
                Stats = stats
            };
        }
    }
}
