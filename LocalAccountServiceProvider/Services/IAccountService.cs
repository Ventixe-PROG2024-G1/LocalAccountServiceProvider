using Grpc.Core;

namespace LocalAccountServiceProvider.Services
{
    public interface IAccountService
    {
        Task<AccountServiceResult> CreateAccount(CreateAccountRequest request, ServerCallContext context);
        Task<AccountServiceResult> FindByEmail(FindByEmailRequest request, ServerCallContext context);
        Task<AccountResponse> GetAccount(GetAccountRequest request, ServerCallContext context);
        Task<AllAccountsResponse> GetAllAccounts(GetAccountRequest request, ServerCallContext context);
        Task<string> GetUserRoleById(string id);
    }
}