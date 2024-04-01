using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.Entities.Courses;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.DataLayer.DTOs.Course
{
	public class RequestProjectDto
	{
        public int RequestProjectId { get; set; }
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public string StudentFullName { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string Title { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string Description { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string Puprpose { get; set; }

        [Range(1, 4, ErrorMessage = ApplicationMessages.RequiredField)]
        public ProjectType ProjectType { get; set; }

        public string CreationDate { get; set; }
        public string TeammateName { get; set; }
        public string TeammateStudentCode { get; set; }
        public int CourseId { get; set; } = 1;

        [Range(typeof(bool), "true", "true", ErrorMessage = ApplicationMessages.RequiredField)]
        public bool AcceptTerms { get; set; }

        [Range(1, 5, ErrorMessage = ApplicationMessages.RequiredField)]
        public Platform Platform { get; set; }

        public AcceptSituation Situation { get; set; }
        public ProjectStep Step { get; set; }

        public int TeacherId { get; set; }
        public string TeacherFullName { get; set; }

        public string Feedback { get; set; }
        public bool IsRemoved { get; set; }

        public string ProjectTypeName { get; set; }
        public string PlatformName { get; set; }
        public string SituationName { get; set; }
    }
}
