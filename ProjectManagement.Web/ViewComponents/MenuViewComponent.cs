using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Web.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Menu");
        }
    }
}
