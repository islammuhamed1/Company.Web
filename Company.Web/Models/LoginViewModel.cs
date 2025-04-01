using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Required!!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
