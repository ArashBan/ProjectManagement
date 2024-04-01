using ProjectManagement.DataLayer.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.DataLayer.Entities.Courses
{
    public class ProjectProgress : BaseEntity
    {
        public int ProjectId { get; set; }
        public ProjectRequest Project { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Feedback { get; set; }

        public ProgressResult Result { get; set; }

        public void Read(string feedback)
        {
            Result = ProgressResult.Seen;
            Feedback = feedback;
        }
    }

    public enum ProgressResult
    {
        [Display(Name = "در انتظار بررسی")]
        UnderProgress = 1,

        [Display(Name = "دیده شده")]
        Seen = 2
    }
}
