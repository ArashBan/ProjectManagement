namespace ProjectManagement.DataLayer.DTOs.Common
{
    public class MainFormDto
    {
        public MainFormStats Stats { get; set; }
    }

    public class MainFormStats
    {
        public int StudentsCount { get; set; }
        public int TeachersCount { get; set; }
        public int RequestsCount { get; set; }
        public int QuestionsCount { get; set; }
    }
}
