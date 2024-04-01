using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.Entities.Courses;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.DataLayer.DTOs.Course
{
    public class ProjectProgressDto
    {
        public int ProjectProgressId { get; set; }

        public int ProjectId { get; set; }
        public int StudentId { get; set; }

        public string StudentFullName { get; set; }
        public string StudentCode { get; set; }

        public string TeammateFullName { get; set; }
        public string TeammateStudentCode { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string Title { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string Description { get; set; }

        public string Feedback { get; set; }

        public ProgressResult Result { get; set; }
        public string CreationDate { get; set; }
    }
}
