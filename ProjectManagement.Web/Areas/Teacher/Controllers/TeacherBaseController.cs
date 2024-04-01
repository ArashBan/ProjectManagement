using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Web.Models;

namespace ProjectManagement.Web.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Route("teacher")]
    [StudentAuthorizeActionFilter]
    public class TeacherBaseController : Controller
    {
    }
}
