using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.DataLayer.Entities.People;

namespace ProjectManagement.DataLayer.Entities.Courses
{
    public class Enrollment : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
