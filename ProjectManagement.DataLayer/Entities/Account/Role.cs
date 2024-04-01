using ProjectManagement.DataLayer.Entities.Common;

namespace ProjectManagement.DataLayer.Entities.Account
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public List<Permission> Permissions { get; set; }
    }
}
