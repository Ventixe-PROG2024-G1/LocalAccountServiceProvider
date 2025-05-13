using Grpc.Core;
using LocalAccountServiceProvider.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LocalAccountServiceProvider.Services
{
    public class AccountService(UserManager<AppUserEntity> userManager,
            RoleManager<IdentityRole> roleManager
            ) : AccountContract.AccountContractBase, IAccountService
    {
        // userManager innehåller repository med färdig funktionalitet för att kommunicera med databasen
        private readonly UserManager<AppUserEntity> _userManager = userManager;

        private readonly RoleManager<IdentityRole> _roleManager = roleManager;

        public override async Task<AccountServiceResult> CreateAccount(CreateAccountRequest request, ServerCallContext context)
        {
            try
            {
                // Gör factory
                var appUser = new AppUserEntity
                {
                    UserName = request.Email,
                    Email = request.Email,
                };

                var userExists = await _userManager.Users.AnyAsync();
                // Om userExists är true sätts rollen till User
                var role = userExists ? "User" : "Admin";

                var response = await _userManager.CreateAsync(appUser, request.Password);
                if (response.Succeeded)
                {
                    appUser.EmailConfirmed = true;

                    await _userManager.AddToRoleAsync(appUser, role);

                    return new AccountServiceResult { Success = true, Result = appUser.Id };
                }
                return new AccountServiceResult { Success = false, Error = string.Join(", ", response.Errors) };
            }
            catch (Exception ex)
            {
                return new AccountServiceResult { Success = false, Error = ex.Message };
            }
        }

        public override async Task<AccountServiceResult> FindByEmail(FindByEmailRequest request, ServerCallContext context)
        {
            var result = await _userManager.Users.AnyAsync(x => x.Email == request.Email);
            if (result)
            {
                return new AccountServiceResult { Success = true };
            }
            return new AccountServiceResult { Success = false, Error = "Account not found" };
        }

        public override async Task<AccountResponse> GetAccount(GetAccountRequest request, ServerCallContext context)
        {
            var account = await _userManager.FindByIdAsync(request.Id);
            var role = await GetUserRoleById(request.Id);
            return new AccountResponse
            {
                Id = account.Id,
                Email = account.Email,
                Role = role,
            };
        }

        public override async Task<AllAccountsResponse> GetAllAccounts(GetAccountRequest request, ServerCallContext context)
        {
            var accounts = await _userManager.Users.ToListAsync();

            var response = new AllAccountsResponse();

            foreach (var account in accounts)
            {
                var role = await GetUserRoleById(account.Id);

                response.Accounts.Add(new AccountResponse
                {
                    Id = account.Id,
                    Email = account.Email,
                    Role = role,
                });
            }

            return response;
        }

        public async Task<string> GetUserRoleById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }

            var role = await _userManager.GetRolesAsync(user);
            return role.FirstOrDefault();
        }
    }
}