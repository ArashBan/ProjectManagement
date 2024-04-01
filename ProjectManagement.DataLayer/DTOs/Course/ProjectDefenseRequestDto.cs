using System.ComponentModel.DataAnnotations;
using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.Entities.Courses;

namespace ProjectManagement.DataLayer.DTOs.Course
{
    public class ProjectDefenseRequestDto
    {
        public int DefenseRequestId { get; set; }

        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string Date { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string Time { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string Place { get; set; }

        public AcceptSituation Situation { get; set; }
        public string CreationDate { get; set; }
        public string StudentName { get; set; }
        public string ProjectName { get; set; }
        public string TeammateName { get; set; }
        public string TeammateCode { get; set; }
        public string StudentCode { get; set; }
        public int ProgressCount { get; set; }
        public string TeacherName { get; set; }

        public int StudentUserId { get; set; }
    }
}
