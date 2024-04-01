using ProjectManagement.DataLayer.Entities.Common;
using ProjectManagement.DataLayer.Entities.People;

namespace ProjectManagement.DataLayer.Entities.Account
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsStudent { get; set; }

        public Student Student { get; set; }
        public Teacher Teacher { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public List<Notification> Notifications { get; set; }
    }
}
