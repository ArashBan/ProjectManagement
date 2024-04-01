using ProjectManagement.DataLayer.Entities.Common;

namespace ProjectManagement.DataLayer.DTOs.Common
{
    public class ProblemDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public InfoType Type { get; set; }
        public string TypeName { get; set; }
    }
}
