namespace ProjectManagement.Application.Utils
{
    public static class Roles
    {
        public const string Student = "1";
        public const string Teacher = "2";

        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "دانشجو";
                case 2:
                    return "استاد";
                default:
                    return "";
            }
        }
    }
}
