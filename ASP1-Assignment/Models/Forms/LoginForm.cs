using System.ComponentModel.DataAnnotations;

namespace ASP1_Assignment.Models.Forms
{
    public class LoginForm
    {
        [Required]
        [Display(Name = "E-Mail Address")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Keep Me Logged In")]
        public bool KeepLoggedIn { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
