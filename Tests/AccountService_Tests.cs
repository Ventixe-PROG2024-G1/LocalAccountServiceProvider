using LocalAccountServiceProvider.Data.Contexts;
using LocalAccountServiceProvider.Data.Entities;
using LocalAccountServiceProvider.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LocalAccountServiceProvider.Data.DTOs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;

namespace Tests
{
    public class AccountService_Tests
    {
        #region Configurations

        private readonly ServiceProvider _provider;
        private readonly UserManager<AppUserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AuthenticationContext _context;
        private readonly IAccountService _accountService;

        public AccountService_Tests()
        {
            var services = new ServiceCollection();

            services.AddDbContext<AuthenticationContext>(x => x.UseInMemoryDatabase($"{Guid.NewGuid()}"));

            services.AddIdentity<AppUserEntity, IdentityRole>(x =>
            {
                x.User.RequireUniqueEmail = true;
                x.Password.RequiredLength = 8;
                x.SignIn.RequireConfirmedPhoneNumber = true;
            })
            .AddEntityFrameworkStores<AuthenticationContext>();
            services.AddLogging();

            // **AI-genererad kod**
            // Jag använde mig av AI-genererad kod för att skapa upp rollerna i InMemory-databasen
            services.AddScoped<IRoleStore<IdentityRole>, RoleStore<IdentityRole, AuthenticationContext>>();
            services.AddScoped<IdentityErrorDescriber>();
            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddScoped<ILogger<RoleManager<IdentityRole>>, Logger<RoleManager<IdentityRole>>>();

            _provider = services.BuildServiceProvider();

            // Tilldelar värden till instansvariabler
            _userManager = _provider.GetRequiredService<UserManager<AppUserEntity>>();
            _roleManager = _provider.GetRequiredService<RoleManager<IdentityRole>>();
            _context = _provider.GetRequiredService<AuthenticationContext>();
            _accountService = new AccountService(_userManager);

            // Här skaps rollerna upp i InMemory-databasen
            InitializeRolesAsync().Wait();
        }

        private async Task InitializeRolesAsync()
        {
            string[] roleNames = { "Admin", "User" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _provider.Dispose();
        }

        #endregion Configurations

        [Fact]
        public async Task CreateAccount_ShouldReturnSuccess_WhenValidDataProvided()
        {
            // Arrange
            var request = new CreateAccountRequestRest
            {
                Email = "test@domain.com",
                Password = "Bytmig123!"
            };

            // Act
            var response = await _accountService.CreateAccount(request);

            // Assert
            Assert.True(response.Success);

            var user = await _userManager.FindByEmailAsync(request.Email);
            Assert.NotNull(user);

            Dispose();
        }

        [Fact]
        public async Task FindByEmail_ShouldReturnTrue_IfAccountExists()
        {
            await _userManager.CreateAsync(new AppUserEntity { UserName = "test@domain.com", Email = "test@domain.com" });
            var request = new FindByEmailRequestRest
            {
                Email = "test@domain.com",
            };

            var response = await _accountService.FindByEmail(request);

            Assert.True(response.Success);

            Dispose();
        }
    }
}