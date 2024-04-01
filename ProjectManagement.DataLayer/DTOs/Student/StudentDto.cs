namespace ProjectManagement.DataLayer.DTOs.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string StudentCode { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Field { get; set; }
        public string Semester { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
        public List<StudentCourse> Courses { get; set; }
        public string CourseNames { get; set; }

        public bool HasCourse(int courseId)
        {
            return Courses.Any(x => x.CourseId == courseId);
        }

        public int GetCourseTeacherId(int courseId)
        {
            return Courses.FirstOrDefault(x => x.CourseId == courseId).TeacherId;
        }
    }
}