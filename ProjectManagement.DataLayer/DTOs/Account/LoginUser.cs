using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.DataLayer.DTOs.Account
{
    public class LoginUser
    {

        [Display(Name = "شماره دانشجویی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Username { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
        public bool IsStudent { get; set; }
    }

    public enum LoginUserResult
    {
        Success,
        NotFound
    }
}
