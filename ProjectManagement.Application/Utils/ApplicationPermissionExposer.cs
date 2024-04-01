using ProjectManagement.Application.Utils;

namespace ShopManagement.Configuration.Permissions
{
    public class ApplicationPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "Student", new List<PermissionDto>
                    {
                        new PermissionDto(AppicationPermissions.StudentArea, "صفحه اصلی دانشجو"),

                    }
                },
                {
                    "Teacher", new List<PermissionDto>
                    {
                        new PermissionDto(AppicationPermissions.TeacherArea, "صفحه اصلی استاد"),
                    }
                }
            };
        }
    }
}
