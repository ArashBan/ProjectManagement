using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.DataLayer.Entities.People;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.DataLayer.Entities.Courses
{
    public class ProjectRequest : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Puprpose { get; set; }
        public string Feedback { get; set; }
        public ProjectType ProjectType { get; set; }

        public string TeammateName { get; set; }
        public string TeammateStudentCode { get; set; }

        public DateTime? TeacherAcceptDate { get; set; }
        public DateTime? ParentAcceptDate { get; set; }

        public Platform Platform { get; set; }
        public AcceptSituation Situation { get; set; }
        public ProjectStep Step { get; set; }


        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<ProjectProgress> ProjectProgresses { get; set; }
        public List<ProjectDefenseRequest> DefenseRequests { get; set; }

        public void ChangeSituation(AcceptSituation situation)
        {
            Situation = situation;
            if (situation == AcceptSituation.Confirm)
            {
                if (Teacher.ParentId == 0)
                {
                    TeacherAcceptDate = DateTime.Now;
                    ParentAcceptDate = DateTime.Now;
                }
                else
                    ParentAcceptDate = DateTime.Now;

                Step = ProjectStep.Confirm;
            }
            else
            {
                switch (situation)
                {
                    case AcceptSituation.Accepted:
                        Step = ProjectStep.Accept;
                        TeacherAcceptDate = DateTime.Now;
                        break;
                    case AcceptSituation.UnderProgress:
                        Step = ProjectStep.Request;
                        TeacherAcceptDate = null;
                        ParentAcceptDate = null;
                        break;
                    case AcceptSituation.Rejected:
                        Step = ProjectStep.Request;
                        if (Teacher.ParentId == 0)
                            ParentAcceptDate = null;
                        else
                            TeacherAcceptDate = null;
                        break;
                }
            }
        }
    }

    public enum Platform
    {
        [Display(Name = "ویندوز")]
        Windows = 1,

        [Display(Name = "وب")]
        Web = 2,

        [Display(Name = "موبایل")]
        Mobile = 3,

        [Display(Name = "سایر")]
        Other = 4
    }

    public enum ProjectType
    {
        [Display(Name = "برنامه نویسی")]
        Programming = 1,

        [Display(Name = "تحقیقاتی")]
        Researching = 2,

        [Display(Name = "ساخت")]
        Handmade = 3
    }

    public enum AcceptSituation
    {
        [Display(Name = "در انتظار بررسی")]
        UnderProgress = 1,

        [Display(Name = "تایید استاد راهنما")]
        Accepted = 2,

        [Display(Name = "تایید نهایی")]
        Confirm = 3,

        [Display(Name = "رد شده")]
        Rejected = 4
    }

    public enum ProjectStep
    {
        Request = 1,
        Accept = 2,
        Confirm = 3,
        MonthlyReport = 4,
        Documents = 5,
        RequestDefenseSession = 6,
        DefenseSessionDone = 7
    }
}