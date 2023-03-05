using ASP1_Assignment.Models.Forms;
using ASP1_Assignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP1_Assignment.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuthService _auth;

        public LoginController(AuthService auth)
        {
            _auth = auth;
        }

        public IActionResult Index(string ReturnUrl = null!)
        {
            var form = new LoginForm { ReturnUrl = ReturnUrl ?? Url.Content("~/") };

            return View(form);
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginForm loginForm)
        {
            if(ModelState.IsValid)
            {
                if(await _auth.LoginAsync(loginForm))
                {
                    return LocalRedirect(loginForm.ReturnUrl!);
                }

                // i 10:an ligger errormeddelandet här

            }
            ModelState.AddModelError(string.Empty, "Incorrect email or password");
            return View(loginForm);
        }

        public async Task<IActionResult> Logout()
        {
            await _auth.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
