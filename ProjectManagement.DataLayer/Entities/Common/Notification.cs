using ProjectManagement.DataLayer.Entities.Account;

namespace ProjectManagement.DataLayer.Entities.Common
{
    public class Notification : BaseEntity
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public NotificationType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public void Read()
        {
            IsRead = true;
        }
    }

    public enum NotificationType 
    {
        Success = 1,
        Fail = 2,
        Information = 3,
        Warning = 4
    }
}
