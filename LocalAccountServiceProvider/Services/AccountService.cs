using Grpc.Core;
using LocalAccountServiceProvider.Data.DTOs;
using LocalAccountServiceProvider.Data.Entities;
using LocalAccountServiceProvider.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LocalAccountServiceProvider.Services
{
    public class AccountService(UserManager<AppUserEntity> userManager
            ) : IAccountService
    {
        private readonly UserManager<AppUserEntity> _userManager = userManager;

        public async Task<AccountServiceResultRest> CreateAccount(CreateAccountRequestRest request)
        {
            try
            {
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

                    return new AccountServiceResultRest { Success = true, Result = appUser.Id };
                }
                return new AccountServiceResultRest { Success = false, Error = string.Join(", ", response.Errors) };
            }
            catch (Exception ex)
            {
                return new AccountServiceResultRest { Success = false, Error = ex.Message };
            }
        }

        public async Task<AccountServiceResultRest> FindByEmail(FindByEmailRequestRest request)
        {
            var result = await _userManager.Users.AnyAsync(x => x.Email == request.Email);
            if (result)
            {
                return new AccountServiceResultRest { Success = true };
            }
            return new AccountServiceResultRest { Success = false, Error = "Account not found" };
        }

        public async Task<AccountResponseRest> GetAccount(GetAccountRequestRest request)
        {
            var account = await _userManager.FindByIdAsync(request.Id);
            var role = await GetUserRoleById(request.Id);
            return new AccountResponseRest
            {
                Id = account.Id,
                Email = account.Email,
                Role = role,
            };
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