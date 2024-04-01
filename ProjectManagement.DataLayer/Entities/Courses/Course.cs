using ProjectManagement.DataLayer.Entities.Common;

namespace ProjectManagement.DataLayer.Entities.Courses
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public byte Unit { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}
