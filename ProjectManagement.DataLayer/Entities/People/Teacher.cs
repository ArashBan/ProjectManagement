using ProjectManagement.DataLayer.Entities.Account;
using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.DataLayer.Entities.Courses;

namespace ProjectManagement.DataLayer.Entities.People
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }

        public int ParentId { get; set; }
        public Teacher Parent { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public bool Project { get; set; }
        public bool Internship { get; set; }

        public List<Enrollment> Enrollments { get; set; }
        public List<ProjectRequest> ProjectRequests { get; set; }
        public List<InternshipRequest> InternshipRequests { get; set; }
        public List<ProjectDefenseRequest> DefenseRequests { get; set; }
        public List<News> News { get; set; }
    }
}
