using ProjectManagement.DataLayer.Entities.Common;

namespace ProjectManagement.DataLayer.DTOs.Common
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public int UserId { get; set; }
        public bool IsRead { get; set; }

        public NotificationType Type { get; set; }
    }
}