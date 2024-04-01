using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.DataLayer.Entities.Common
{
    public class Problem : BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public InfoType Type { get; set; }
    }

    public enum InfoType
    {
        [Display(Name = "پروژه")]
        Project = 1,

        [Display(Name = "کارآموزی")]
        Internship = 2,

        [Display(Name = "عمومی")]
        Common = 3
    }
}
