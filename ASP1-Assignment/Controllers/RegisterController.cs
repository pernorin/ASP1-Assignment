using ASP1_Assignment.Models.Forms;
using ASP1_Assignment.Models.Identity;
using ASP1_Assignment.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace ASP1_Assignment.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AuthService _auth;
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(AuthService auth, UserManager<AppUser> userManager)
        {
            _auth = auth;
            _userManager = userManager;
        }

        public IActionResult Index(string ReturnUrl = null!)
        {
            var form = new RegisterForm { ReturnUrl = ReturnUrl ?? Url.Content("~/") };

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterForm registerForm)
        {
            if(ModelState.IsValid)
            {
                
                // borde kanske ligga i en service (3:15)
                if (await _userManager.Users.AnyAsync(x => x.Email  == registerForm.Email))
                {
                    ModelState.AddModelError(string.Empty, "There is already a user with that email.");
                    return View(registerForm);
                }

                if (await _auth.RegisterAsync(registerForm))
                {
                    return LocalRedirect(registerForm.ReturnUrl!);
                }
                else
                {
                    return View(registerForm);  // Behövs det en else här?
                }
            }
            return View(registerForm);



        }
    }
}
