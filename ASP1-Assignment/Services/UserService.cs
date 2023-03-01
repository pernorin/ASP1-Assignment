using ASP1_Assignment.Contexts;
using ASP1_Assignment.Models.Entities;
using ASP1_Assignment.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASP1_Assignment.Services
{
    public class UserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IdentityContext _identityContext;

        

        public UserService(UserManager<IdentityUser> userManager, IdentityContext identityContext)
        {
            _userManager = userManager;
            _identityContext = identityContext;
        }

        public async Task<UserAccount> GetUserAccountAsync(string id)  // 3:21
        {
            var identityUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (identityUser != null) 
            {
                var identityProfile = await _identityContext.UserProfiles.FirstOrDefaultAsync(x => x.UserId == identityUser.Id);
                if (identityProfile != null)
                {
                    return new UserAccount
                    {
                        Id = identityUser.Id,
                        FirstName = identityProfile.FirstName,
                        LastName = identityProfile.LastName,
                        Email = identityUser.Email!,
                        PhoneNumber = identityUser.PhoneNumber,
                        StreetName = identityProfile.StreetName,
                        City = identityProfile.City,
                        PostalCode = identityProfile.PostalCode,
                        Company = identityProfile.Company,
                    };
                }
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
