using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VertexCore.WebAPI.IntegrationTests
{
    public class CustomWebAppFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddAuthentication("Test")
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => { });

                services.AddAuthorization(options =>
                {
                    options.DefaultPolicy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder("Test")
                        .RequireAuthenticatedUser()
                        .Build();
                });

                // Replace real DB with in-memory DB for tests
                services.AddDbContext<VertexCore.Infrastructure.Identity.ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("TestDb");
                });
            });

            builder.UseEnvironment("Testing");
        }
    }
}
