using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.DataLayer.Entities.People;

namespace ProjectManagement.DataLayer.Entities.Courses
{
    public class ProjectDefenseRequest : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int ProjectId { get; set; }
        public ProjectRequest Project { get; set; }

        public string Date { get; set; }
        public string Time { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public AcceptSituation Situation { get; set; }
    }
}
