using System.Security.Claims;
using System.Security.Principal;

namespace ProjectManagement.Web.PresentationExtensions
{
    public static class IdentityExtensions
	{
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var data = claimsPrincipal.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                if (data != null) return Convert.ToInt32(data.Value);
            }

            return default;
        }

        public static int GetUserId(this IPrincipal principal)
        {
            var user = (ClaimsPrincipal)principal;
            return user.GetUserId();
        }


        public static int GetId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var data = claimsPrincipal.Claims.SingleOrDefault(x => x.Type == "PersonId");
                if (data != null) return Convert.ToInt32(data.Value);
            }

            return default;
        }

        public static int GetId(this IPrincipal principal)
        {
            var user = (ClaimsPrincipal)principal;
            return user.GetId();
        }


        public static bool IsStudent(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var data = claimsPrincipal.Claims.SingleOrDefault(x => x.Type == "IsStudent");
                if (data != null) return Convert.ToBoolean(data.Value);
            }

            return default;
        }


        public static string GetUserFullName(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var data = claimsPrincipal.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name);
                if (data != null) return data.Value;
            }

            return default;
        }

        public static string GetUserFullName(this IPrincipal principal)
        {
            var user = (ClaimsPrincipal)principal;
            return user.GetUserFullName();
        }


        public static string GetStudentCode(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var data = claimsPrincipal.Claims.SingleOrDefault(x => x.Type == "StudentCode");
                if (data != null) return data.Value;
            }

            return default;
        }

        public static string GetStudentCode(this IPrincipal principal)
        {
            var user = (ClaimsPrincipal)principal;
            return user.GetStudentCode();
        }


        public static string GetNationalCode(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var data = claimsPrincipal.Claims.SingleOrDefault(x => x.Type == "NationalCode");
                if (data != null) return data.Value;
            }

            return default;
        }

        public static string GetNationalCode(this IPrincipal principal)
        {
            var user = (ClaimsPrincipal)principal;
            return user.GetNationalCode();
        }

        public static bool IsParent(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var data = claimsPrincipal.Claims.SingleOrDefault(x => x.Type == "IsParent");
                if (data != null) return Convert.ToBoolean(data.Value);
            }

            return default;
        }

        public static bool IsParent(this IPrincipal principal)
        {
            var user = (ClaimsPrincipal)principal;
            return user.IsParent();
        }
    }
}
