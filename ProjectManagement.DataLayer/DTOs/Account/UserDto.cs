namespace ProjectManagement.DataLayer.DTOs.Account
{
    public class UserDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsStudent { get; set; }
        public bool IsParent { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public string FullName { get; set; }
        public string StudentCode { get; set; }
        public string NationalCode { get; set; }
    }

    public class RoleDto
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
    }
}
