using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Socializer_001.Areas.Identity.Data;
using Socializer_001.Models;

namespace Socializer_001.Services
{
    public class GetUserOptionalDataAsync
    {
        private readonly AuthenticationDBContext AuthenticationDBContext;
        public GetUserOptionalDataAsync(AuthenticationDBContext db)
        {
            AuthenticationDBContext = db;
        }
        ApplicationUser FullUser = new ApplicationUser();

        public async Task<ApplicationUser> GetUserFullDataAsync(IdentityUser user)
        {
            FullUser = AuthenticationDBContext.Users.FirstOrDefault(x => x.Id == user.Id);
            if (FullUser != null)
            {
                return FullUser;
            }
            else throw new ArgumentNullException(nameof(user), "User Not Found!");
        }
        public async Task<ApplicationUser> GetUserByIDAsync(string userId)
        {
            FullUser = await AuthenticationDBContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (FullUser != null)
            {
                return FullUser;
            }
            else throw new ArgumentNullException(nameof(userId), "User Not Found!");
        }
        public async Task<string> GetUserFirstName(string userId)
        {
            FullUser = await GetUserByIDAsync(userId);
            if (FullUser != null)
            {
                return FullUser.FirstName;
            }
            else throw new ArgumentNullException(nameof(userId),"User Not Found!");
        }
    }
}
