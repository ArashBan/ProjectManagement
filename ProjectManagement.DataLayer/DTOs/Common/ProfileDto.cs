using ProjectManagement.DataLayer.DTOs.Course;
using ProjectManagement.DataLayer.DTOs.Student;
using ProjectManagement.DataLayer.DTOs.Teacher;

namespace ProjectManagement.DataLayer.DTOs.Common
{
    public class StudentProfileDto
    {
        public StudentDto Student { get; set; }
        public RequestProjectDto Project { get; set; }
        public InternshipDto Internship { get; set; }

        public List<ProjectProgressDto> ProjectProgresses { get; set; } = new List<ProjectProgressDto>();
        public List<InternshipReportDto> InternshipReports { get; set; } = new List<InternshipReportDto>();
    }

    public class TeacherProfileDto
    {
        public TeacherDto Teacher { get; set; }
        public string Courses { get; set; }
        public TeacherStatsDto Stats { get; set; }
    }

    public class TeacherStatsDto
    {
        public int ProjectRequestsCount { get; set; }
        public int InternshipRequestsCount { get; set; }

        public int NewProjectProgressesCount { get; set; }
        public int NewInternshipReportsCount { get; set; }

        public int NewProjectRequests { get; set; }
        public int NewInternshipRequests { get; set; }

        public int ProjectStudentsCount { get; set; }
        public int InternshipStudentsCount { get; set; }
    }
}
