using LocalAccountServiceProvider.Data.Contexts;
using LocalAccountServiceProvider.Data.Entities;
using LocalAccountServiceProvider.Middlewares;
using LocalAccountServiceProvider.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AuthenticationContext>(x =>
x.UseSqlServer(builder.Configuration.GetConnectionString("ConnStringAuthentication")));

builder.Services.AddIdentity<AppUserEntity, IdentityRole>().AddEntityFrameworkStores<AuthenticationContext>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddGrpc();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

//app.MapGrpcService<AccountService>();
//app.MapGet("/", () => "AccountServiceProvider is running.");
app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthentication();
app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();