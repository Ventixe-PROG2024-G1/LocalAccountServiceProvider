using LocalAccountServiceProvider.Models;

namespace LocalAccountServiceProvider.Services
{
    public interface IAppUserService
    {
        Task<IEnumerable<AppUser>> GetAllAppUsers();
        Task<AppUser> GetAppUserById(string id);
    }
}