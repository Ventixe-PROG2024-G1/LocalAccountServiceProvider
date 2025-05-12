using LocalAccountServiceProvider.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LocalAccountServiceProvider.Data.Contexts
{
    public class AuthenticationContext(DbContextOptions<AuthenticationContext> options) : IdentityDbContext<AppUserEntity>(options)
    {
    }
}