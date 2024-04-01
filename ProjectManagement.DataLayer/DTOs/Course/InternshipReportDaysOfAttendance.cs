namespace ProjectManagement.DataLayer.DTOs.Course
{
    public class InternshipReportDaysOfAttendance
    {
        public string Day { get; set; }
        public string DayEnglish { get; set; }
        public byte DayIndex { get; set; }

        public string GenerateDayNameByIndex(string name)
        {
            switch (name)
            {
                case "شنبه":
                    return "Saturday";
                case "یکشنبه":
                    return "Sunday";
                case "دوشنبه":
                    return "Monday";
                case "سه شنبه":
                    return "Tuesday";
                case "چهارشنبه":
                    return "Wednesday";
                case "پنجشنبه":
                    return "Thursday";
                default:
                    return "";
            }
        }
    }
}
