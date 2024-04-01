using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Web.ViewComponents
{
    public class TeacherMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("TeacherMenu");
        }
    }
}