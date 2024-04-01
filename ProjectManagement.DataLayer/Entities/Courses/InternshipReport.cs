using ProjectManagement.DataLayer.Entities.Common;

namespace ProjectManagement.DataLayer.Entities.Courses
{
    public class InternshipReport : BaseEntity
    {
        public int InternshipId { get; set; }
        public InternshipRequest Internship { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string Saturday { get; set; }
        public string Sunday { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }

        public string Feedback { get; set; }

        public ProgressResult Result { get; set; }

        public void Read(string feedback)
        {
            Result = ProgressResult.Seen;
            Feedback = feedback;
        }
    }
}
