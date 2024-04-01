using ProjectManagement.DataLayer.Entities.People;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.DataLayer.Entities.Common
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public InfoType Type { get; set; }
        public Importance Importance { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }

    public enum Importance
    {
        [Display(Name = "اطلاع رسانی")]
        Information = 1,

        [Display(Name = "فوری")]
        Instant = 2,

        [Display(Name = "مهم")]
        Important = 3
    }
}
