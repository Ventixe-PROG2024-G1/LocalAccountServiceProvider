
namespace LocalAccountServiceProvider.Services
{
    public interface IProfileService
    {
        Task<ProfileResponse> GetProfile(string id);
        Task<AllProfilesResponse> GetProfiles();
    }
}