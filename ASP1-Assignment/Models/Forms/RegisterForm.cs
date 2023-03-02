using System.ComponentModel.DataAnnotations;

namespace ASP1_Assignment.Models.Forms
{
    public class RegisterForm
    {
        [Required]
        [Display(Name = "First Name")]        
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail Address")]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Street Name")]
        public string StreetName { get; set; } = null!;

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = null!;

        [Required]
        [Display(Name = "City")]
        public string City { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Company")]
        public string? Company { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
