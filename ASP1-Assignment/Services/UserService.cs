using ASP1_Assignment.Contexts;
using ASP1_Assignment.Models.Entities;
using ASP1_Assignment.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASP1_Assignment.Services
{
    public class UserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IdentityContext _identityContext;

        

        public UserService(UserManager<AppUser> userManager, IdentityContext identityContext)
        {
            _userManager = userManager;
            _identityContext = identityContext;
        }

        
        public async Task<UserAccount> GetUserAccountAsync(string id)  // 3:21
        {
           

            var identityUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (identityUser != null) 
            {
                return new UserAccount
                {
                    Id = identityUser.Id,
                    FirstName = identityUser.FirstName,
                    LastName = identityUser.LastName,
                    Email = identityUser.Email!,
                    StreetName = identityUser.StreetName,
                    PhoneNumber = identityUser.PhoneNumber,
                    PostalCode = identityUser.PostalCode,
                    City = identityUser.City
                };
            }
            return null!;
        }

        /*
        public async Task<IdentityUser> GetUserAsync(Func<IdentityUser, bool> predicate)
        {
            //var user = await _userManager.Users.FirstOrDefaultAsync(predicate);

        }
        */
    }
}
