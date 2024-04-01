using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Web.ViewComponents;

public class TeacherToolbarViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View("TeacherToolbar");
    }
}
