
using ASP1_Assignment.Contexts;
using ASP1_Assignment.Models.Entities;
using ASP1_Assignment.Models.Forms;
using Microsoft.AspNetCore.Identity;

namespace ASP1_Assignment.Services
{
    public class AuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IdentityContext _identityContext;

        public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _identityContext = identityContext;
            _signInManager = signInManager;
        }

        public async Task<bool> RegisterAsync(RegisterForm form)
        {
            var identityUser = new IdentityUser
            {
                UserName = form.Email,
                Email = form.Email,
                PhoneNumber = form.PhoneNumber,
            };
            var userProfile = new UserProfileEntity
            {
                UserId = identityUser.Id,
                FirstName = form.FirstName,
                LastName = form.LastName,
                StreetName = form.StreetName,
                PostalCode = form.PostalCode,
                City = form.City,
                Company = form.Company,
            };

            var result = await _userManager.CreateAsync(identityUser, form.Password);
            if (result.Succeeded)
            {
                _identityContext.UserProfiles.Add(userProfile);
                await _identityContext.SaveChangesAsync();
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
