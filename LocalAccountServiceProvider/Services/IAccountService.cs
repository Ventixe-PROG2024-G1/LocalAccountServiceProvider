using Grpc.Core;
using LocalAccountServiceProvider.Models;

namespace LocalAccountServiceProvider.Services
{
    public interface IAccountService
    {
        Task<AccountServiceResult> CreateAccount(CreateAccountRequest request, ServerCallContext context);
        Task<AccountServiceResult> FindByEmail(FindByEmailRequest request, ServerCallContext context);
        Task<IEnumerable<AppIdentityUser>> GetAllUserIdentities();
        Task<AppIdentityUser?> GetUserIdentityById(string id);
        Task<string> GetUserRoleById(string id);
    }
}