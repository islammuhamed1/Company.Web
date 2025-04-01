using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "First Name Is Required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is Required")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invaild Format For Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Is Required!!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)(?:.*(\w)(?!\1))*.{6,}$",
        ErrorMessage = "Password must have at least one lowercase letter, one uppercase letter, one digit, one special character, and at least two unique characters.")]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Confirm Password does not match Password ")]
        public string ConfirmPassword { get; set; }
        public string IsAgree { get; set; }
    }
}
