using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Web.Models;

namespace ProjectManagement.Web.Controllers
{
    [Authorize]
    //[NeedsPermission(AppicationPermissions.StudentArea)]
    //[Authorize(Roles = "1")]
    [TeacherAuthorizeActionFilter]
    public class BaseController : Controller
    {
       
    }
}