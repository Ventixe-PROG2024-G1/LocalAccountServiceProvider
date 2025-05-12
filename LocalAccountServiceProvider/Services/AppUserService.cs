using LocalAccountServiceProvider.Models;

namespace LocalAccountServiceProvider.Services
{
    public class AppUserService(IAccountService accountService, IProfileService profileService) : IAppUserService
    {
        private readonly IAccountService _accountService = accountService;
        private readonly IProfileService _profileService = profileService;

        public async Task<AppUser> GetAppUserById(string id)
        {
            var userIdentity = await _accountService.GetUserIdentityById(id);
            var userProfile = await _profileService.GetProfile(id);

            return new AppUser
            {
                Id = id,
                Email = userIdentity.Email,
                FirstName = userProfile.FirstName,
                LastName = userProfile.LastName,
                Image = userProfile.ProfilePictureUrl,
                Role = userIdentity.Role,
                StreetAddress = userProfile.StreetAddress,
                PostalCode = userProfile.ZipCode,
                City = userProfile.City,
            };
        }

        public async Task<IEnumerable<AppUser>> GetAllAppUsers()
        {
            var userProfiles = await _profileService.GetProfiles();
            var identityUsers = await _accountService.GetAllUserIdentities();

            var appUsers = userProfiles.Profiles.Select(profile =>
            {
                var identityUser = identityUsers.FirstOrDefault(user => user.Id == profile.Id);

                return new AppUser
                {
                    Id = identityUser.Id,
                    Email = identityUser.Email,
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Image = profile.ProfilePictureUrl,
                    Role = identityUser.Role,
                    StreetAddress = profile.StreetAddress,
                    PostalCode = profile.ZipCode,
                    City = profile.City,
                };
            }
            );

            return appUsers;
        }
    }
}