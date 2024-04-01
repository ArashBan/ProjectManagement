using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectManagement.Application.Utils;

namespace ProjectManagement.Web
{
    //public class SecurityPageFilter : IPageFilter
    //{
    //    private readonly IAuthHelper _authHelper;

    //    public SecurityPageFilter(IAuthHelper authHelper)
    //    {
    //        _authHelper = authHelper;
    //    }


    //    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    //    {
    //    }

    //    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    //    {
    //        var handlerPermissions = (NeedsPermissionAttribute)context.HandlerMethod.MethodInfo
    //            .GetCustomAttribute(typeof(NeedsPermissionAttribute));

    //        if (handlerPermissions == null)
    //            return;

    //        if (_authHelper.GetPermissions().All(x => x != handlerPermissions.Permission))
    //            context.HttpContext.Response.Redirect("/PageNotFound");

    //    }

    //    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    //    {
    //    }
    //}
}
