using Grpc.Core;
using LocalAccountServiceProvider.Data.DTOs;
using LocalAccountServiceProvider.Data.Models;

namespace LocalAccountServiceProvider.Services
{
    public interface IAccountService
    {
        Task<AccountServiceResultRest> CreateAccount(CreateAccountRequestRest request);

        Task<AccountServiceResultRest> FindByEmail(FindByEmailRequestRest request);

        Task<AccountResponseRest> GetAccount(GetAccountRequestRest request);

        //Task<AllAccountsResponse> GetAllAccounts(GetAccountRequest request, ServerCallContext context);

        Task<string> GetUserRoleById(string id);
    }
}