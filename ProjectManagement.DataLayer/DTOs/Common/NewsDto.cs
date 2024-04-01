using ProjectManagement.DataLayer.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.DataLayer.DTOs.Common
{
    public class NewsDto
    {
        public int NewsId { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string Title { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string Body { get; set; }

        public string CreationDate { get; set; }

        [Range(1, 4, ErrorMessage = ApplicationMessages.RequiredField)]
        public InfoType Type { get; set; }

        [Range(1, 4, ErrorMessage = ApplicationMessages.RequiredField)]
        public Importance Importance { get; set; }

        public int TeacherId { get; set; }
        public string TeacherFullName { get; set; }
    }
}
