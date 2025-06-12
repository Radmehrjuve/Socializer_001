using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
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
            return FullUser;
        }
    }
}
