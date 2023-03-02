
using ASP1_Assignment.Contexts;
using ASP1_Assignment.Models.Entities;
using ASP1_Assignment.Models.Forms;
using ASP1_Assignment.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASP1_Assignment.Services
{
    public class AuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IdentityContext _identityContext;

        public AuthService(UserManager<AppUser> userManager, IdentityContext identityContext, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _identityContext = identityContext;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<bool> RegisterAsync(RegisterForm form)
        {
            var userRoleName = "User";

            if (!await _roleManager.Roles.AnyAsync() || !await _userManager.Users.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("UserManager"));
                await _roleManager.CreateAsync(new IdentityRole("User"));

                userRoleName = "Admin";
            }


            var identityUser = new AppUser
            {
                UserName = form.Email,
                Email = form.Email,
                PhoneNumber = form.PhoneNumber,
                FirstName = form.FirstName,
                LastName = form.LastName,
                StreetName = form.StreetName,
                PostalCode = form.PostalCode,
                City = form.City,
                Company = form.Company
            };


            var result = await _userManager.CreateAsync(identityUser, form.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(identityUser, userRoleName);
                return true;
            }
            

            return false;
        }

        public async Task<bool> LoginAsync(LoginForm form, bool keepLoggedIn = false )
        {
            var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, keepLoggedIn, false);
            return result.Succeeded;
            
        }
    }
}
