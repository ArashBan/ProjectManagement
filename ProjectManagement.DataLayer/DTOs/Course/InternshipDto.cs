using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.Entities.Courses;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.DataLayer.DTOs.Course
{
    public class InternshipDto
    {
        public int InternshipId { get; set; }
        public int StudentId { get; set; }
        public string StudentCode { get; set; }
        public int CourseId { get; set; } = 2;


        public string CreationDate { get; set; }
        public string StudentFullName { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]

        public string Title { get; set; }
        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string Description { get; set; } // نوع فعالیت

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string PlaceName { get; set; } // نام محل

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string PlacePhoneNumber { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string Address { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string SupervisorFullName { get; set; }

        public string DaysOfAttendance { get; set; }
        public string Feedback { get; set; }

        public int TeacherId { get; set; }
        public string TeacherFullName { get; set; }

        public AcceptSituation Situation { get; set; }
        public string SituationName { get; set; }
        public bool IsRemoved { get; set; }

        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }

        public bool AnyDaySelected()
        {
            return Saturday || Sunday || Monday || Tuesday || Wednesday || Thursday;
        }

        public string RenderDaysOfAttendanceToNumber()
        {
            string result = "";
            if (Saturday) result = "0";
            if (Sunday) result += "1";
            if (Monday) result += "2";
            if (Tuesday) result += "3";
            if (Wednesday) result += "4";
            if (Thursday) result += "5";

            return result.Trim();
        }

        public string RenderDaysOfAttendanceToText()
        {
            if (DaysOfAttendance == null) return "-";

            var result = new List<string>();
            if (DaysOfAttendance.Contains("0")) result.Add("شنبه");
            if (DaysOfAttendance.Contains("1")) result.Add("یکشنبه");
            if (DaysOfAttendance.Contains("2")) result.Add("دوشنبه");
            if (DaysOfAttendance.Contains("3")) result.Add("سه شنبه");
            if (DaysOfAttendance.Contains("4")) result.Add("چهارشنبه");
            if (DaysOfAttendance.Contains("5")) result.Add("پنجشنبه");

            return string.Join("، ", result);
        }
    }
}
