using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Password Is Required!!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)(?:.*(\w)(?!\1))*.{6,}$",
         ErrorMessage = "Password must have at least one lowercase letter, one uppercase letter, one digit, one special character, and at least two unique characters.")]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Confirm Password does not match Password ")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
