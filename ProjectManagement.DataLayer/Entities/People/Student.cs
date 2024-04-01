using ProjectManagement.DataLayer.Entities.Account;
using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.DataLayer.Entities.Courses;

namespace ProjectManagement.DataLayer.Entities.People
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string StudentCode { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Field { get; set; }
        public string Semester { get; set; } // نیمسال ورودی
        public string Type { get; set; } // روزانه یا شبانه

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Enrollment> Enrollments { get; set; }
        public List<ProjectRequest> ProjectRequests { get; set; }
        public List<InternshipRequest> InternshipRequests { get; set; }
        public List<ProjectDefenseRequest> DefenseRequests { get; set; }
    }
}
