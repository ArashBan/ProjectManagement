namespace ProjectManagement.DataLayer.DTOs.Teacher
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int ParentId { get; set; }
        public string Parent { get; set; }
        public string FullName { get; set; }
        public bool Project { get; set; }
        public bool Internship { get; set; }
        public int UserId { get; set; }
        public List<int> Courses { get; set; }
        public string CourseNames { get; set; }

        public bool IsParent()
        {
            return ParentId == 0;
        }

        public bool HasCourse(int courseId)
        {
            return Courses.Any(x => x == courseId);
        }
    }
}
