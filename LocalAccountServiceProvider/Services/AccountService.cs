using Grpc.Core;
using LocalAccountServiceProvider.Data.Entities;
using LocalAccountServiceProvider.Models;
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

        public async Task<AppIdentityUser?> GetUserIdentityById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var role = await GetUserRoleById(id);

            return new AppIdentityUser
            {
                Id = user.Id,
                Email = user.Email,
                Role = role
            };
        }

        public async Task<IEnumerable<AppIdentityUser>> GetAllUserIdentities()
        {
            var users = await _userManager.Users.ToListAsync();

            var userIdentities = new List<AppIdentityUser>();

            foreach (var user in users)
            {
                var role = await GetUserRoleById(user.Id);

                userIdentities.Add(new AppIdentityUser
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = role
                });
            }

            return userIdentities;
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