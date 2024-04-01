using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.DataLayer.Entities.People;

namespace ProjectManagement.DataLayer.Entities.Courses
{
    public class InternshipRequest : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public string Title { get; set; }
        public string Description { get; set; } // نوع فعالیت
        public string PlaceName { get; set; } // نام محل
        public string PlacePhoneNumber { get; set; }
        public string Address { get; set; }
        public string SupervisorFullName { get; set; }
        public string DaysOfAttendance { get; set; }
        public string Feedback { get; set; }

        public DateTime? TeacherAcceptDate { get; set; }
        public DateTime? ParentAcceptDate { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<InternshipReport> InternshipReports { get; set; }

        public AcceptSituation Situation { get; set; }

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

                //Step = ProjectStep.Confirm;
            }
            else
            {
                switch (situation)
                {
                    case AcceptSituation.Accepted:
                        //Step = ProjectStep.Accept;
                        TeacherAcceptDate = DateTime.Now;
                        break;
                    case AcceptSituation.UnderProgress:
                        //Step = ProjectStep.Request;
                        TeacherAcceptDate = null;
                        ParentAcceptDate = null;
                        break;
                    case AcceptSituation.Rejected:
                        //Step = ProjectStep.Request;
                        if (Teacher.ParentId == 0)
                            ParentAcceptDate = null;
                        else
                            TeacherAcceptDate = null;
                        break;
                }
            }
        }
    }
}
