using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.Web.PresentationExtensions;

namespace ProjectManagement.Web.ViewComponents
{
    public class ToolbarViewComponent : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public ToolbarViewComponent(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _notificationService.GetNotifications(User.GetUserId());
            return View("Toolbar", data);
        }
    }

    //public class NotificationsViewComponent : ViewComponent
    //{
    //    private readonly INotificationService _notificationService;

    //    public NotificationsViewComponent(INotificationService notificationService)
    //    {
    //        _notificationService = notificationService;
    //    }
    //    public async Task<IViewComponentResult> InvokeAsync()
    //    {
    //        var data = await _notificationService.GetNotifications(User.GetUserId());
    //        return View("Notifications", data);
    //    }
    //}
}
