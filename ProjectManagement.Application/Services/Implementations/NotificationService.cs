using Microsoft.EntityFrameworkCore;
using ProjectManagement.Application.Extensions;
using ProjectManagement.Application.Services.Interfaces;
using ProjectManagement.DataLayer.DTOs.Common;
using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.DataLayer.Repository;

namespace ProjectManagement.Application.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly IGenericRepository<Notification> _notificationRepository;

        public NotificationService(IGenericRepository<Notification> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }


        public async ValueTask DisposeAsync()
        {
            if (_notificationRepository != null)
                await _notificationRepository.DisposeAsync();
        }

        public async Task<List<NotificationDto>> GetNotifications(int userId)
        {
            return await _notificationRepository.GetQuery()
                .Where(x => x.UserId == userId).OrderByDescending(x => x.CreationDate)
                .Take(10)
                .Select(x => new NotificationDto
                {
                    Title = x.Title,
                    Message = x.Message,
                    UserId = x.UserId,
                    Date = CommonExtensions.CalculateTime(DateTime.Now, x.CreationDate),
                    Type = x.Type,
                    IsRead = x.IsRead
                }).ToListAsync();
        }

        public async Task ReadAll(int userId)
        {
            var notfications = await _notificationRepository.GetQuery()
                .Where(x => x.UserId == userId).ToListAsync();

            notfications.ForEach(x => x.IsRead = true);

            await _notificationRepository.SaveChanges();
        }

        public async Task ReadNotification(int notificationId)
        {
            var notification = await _notificationRepository.GetEntityById(notificationId);
            notification.Read();

            await _notificationRepository.SaveChanges();
        }

        public async Task SendNotification(NotificationDto notificationDto)
        {
            var notification = new Notification
            {
                Title = notificationDto.Title,
                Message = notificationDto.Message,
                UserId = notificationDto.UserId,
                Type = notificationDto.Type
            };

            await _notificationRepository.AddEntity(notification);
            await _notificationRepository.SaveChanges();
        }
    }
}
