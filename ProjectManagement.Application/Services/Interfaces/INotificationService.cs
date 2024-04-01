using ProjectManagement.DataLayer.DTOs.Common;

namespace ProjectManagement.Application.Services.Interfaces
{
    public interface INotificationService : IAsyncDisposable
    {
        Task SendNotification(NotificationDto notificationDto);
        Task ReadNotification(int notificationId);
        Task<List<NotificationDto>> GetNotifications(int userId);
        Task ReadAll(int userId);
    }
}
