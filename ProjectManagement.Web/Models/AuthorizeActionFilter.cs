using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectManagement.Web.PresentationExtensions;

namespace ProjectManagement.Web.Models
{
    public class StudentAuthorizeActionFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.IsStudent())
                context.Result = new UnauthorizedResult();
        }
    }

    public class TeacherAuthorizeActionFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.IsStudent())
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "action", "Index" },
                    { "controller", "Home" },
                    { "area", "Teacher" }
                });
                //context.Result = new UnauthorizedResult();
            }
        }
    }
}
