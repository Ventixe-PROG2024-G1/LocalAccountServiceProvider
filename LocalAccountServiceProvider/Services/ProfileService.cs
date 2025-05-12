namespace LocalAccountServiceProvider.Services
{
    public class ProfileService(ProfileContract.ProfileContractClient profileClient) : IProfileService
    {
        private readonly ProfileContract.ProfileContractClient _profileContractClient = profileClient;

        public async Task<ProfileResponse> GetProfile(string id)
        {
            var request = new GetProfileRequest { Id = id };
            var response = await _profileContractClient.GetProfileAsync(request);
            return response;
        }

        public async Task<AllProfilesResponse> GetProfiles()
        {
            var request = new GetAllProfilesRequest();
            var response = await _profileContractClient.GetAllProfilesAsync(request);
            return response;
        }
    }
}