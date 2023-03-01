namespace ASP1_Assignment.Models.Forms
{
    public class LoginForm
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool KeepLoggedIn { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
