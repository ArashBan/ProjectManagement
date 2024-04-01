using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.Entities.Courses;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.DataLayer.DTOs.Course
{
    public class InternshipReportDto
    {
        public int InternshipReportId { get; set; }
        public int InternshipId { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string StartDate { get; set; }

        [Required(ErrorMessage = ApplicationMessages.RequiredField)]
        public string EndDate { get; set; }

        public string Saturday { get; set; }
        public string Sunday { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string DaysOfAttendance { get; set; }

        public string Feedback { get; set; }
        public string CreationDate { get; set; }
        public string StudentFullName { get; set; }
        public string StudentCode { get; set; }

        public ProgressResult Result { get; set; }

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

        public List<InternshipReportDaysOfAttendance> GenerateInputs()
        {
            var inputs = new List<InternshipReportDaysOfAttendance>();

            if (DaysOfAttendance.Contains("0"))
            {
                inputs.Add(new InternshipReportDaysOfAttendance
                {
                    Day = "شنبه",
                    //DayEnglish = "Saturday",
                    DayIndex = 0
                });
            }
            if (DaysOfAttendance.Contains("1"))
            {
                inputs.Add(new InternshipReportDaysOfAttendance
                {
                    Day = "یکشنبه",
                    //DayEnglish = "Sunday",
                    DayIndex = 1
                });
            }
            if (DaysOfAttendance.Contains("2"))
            {
                inputs.Add(new InternshipReportDaysOfAttendance
                {
                    Day = "دوشنبه",
                    //DayEnglish = "Monday",
                    DayIndex = 2
                });
            }
            if (DaysOfAttendance.Contains("3"))
            {
                inputs.Add(new InternshipReportDaysOfAttendance
                {
                    Day = "سه شنبه",
                    //DayEnglish = "Tuesday",
                    DayIndex = 3
                });
            }
            if (DaysOfAttendance.Contains("4"))
            {
                inputs.Add(new InternshipReportDaysOfAttendance
                {
                    Day = "چهارشنبه",
                    //DayEnglish = "Wednesday",
                    DayIndex = 4
                });
            }
            if (DaysOfAttendance.Contains("5"))
            {
                inputs.Add(new InternshipReportDaysOfAttendance
                {
                    Day = "پنجشنبه",
                    //DayEnglish = "Thursday",
                    DayIndex = 5
                });
            }

            return inputs;
        }       
    }
}
