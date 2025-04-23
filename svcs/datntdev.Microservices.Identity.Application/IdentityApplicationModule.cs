using datntdev.Microservices.Common.Modular;
using datntdev.Microservices.Identity.Application.Authorization.Users;
using datntdev.Microservices.Identity.Contracts;
using datntdev.Microservices.Identity.Application.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace datntdev.Microservices.Identity.Application
{
    [DependOn(typeof(IdentityContractsModule))]
    public class IdentityApplicationModule : BaseModule
    {
        public override void ConfigureServices(IServiceCollection services, IConfigurationRoot configs)
        {
            // Add DbContext for Identity
            var connectionString = configs.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Configure Entity Framework Core to use Microsoft SQL Server.
                options.UseSqlServer(connectionString);

                // Register the entity sets needed by OpenIddict.
                options.UseOpenIddict();
            });

            services.AddOpenIddict()
                // Register the OpenIddict core components.
                .AddCore(options =>
                {
                    // Configure OpenIddict to use the Entity Framework Core stores and models.
                    // Note: call ReplaceDefaultEntities() to replace the default entities.
                    options.UseEntityFrameworkCore()
                           .UseDbContext<ApplicationDbContext>();
                })
                // Register the OpenIddict server components.
                .AddServer(options =>
                 {
                     // By default, the OpenIddict server enforces encryption for all the token types it supports.
                     // https://documentation.openiddict.com/configuration/token-formats#disabling-jwt-access-token-encryption
                     options.DisableAccessTokenEncryption();

                     // Enable the token endpoint.
                     options.SetTokenEndpointUris("connect/token");

                     // Enable the client credentials flow.
                     options.AllowClientCredentialsFlow()
                            .AllowPasswordFlow();

                     // Register the signing and encryption credentials.
                     options.AddDevelopmentEncryptionCertificate()
                            .AddDevelopmentSigningCertificate();

                     // Register the ASP.NET Core host and configure the ASP.NET Core options.
                     options.UseAspNetCore()
                            .EnableTokenEndpointPassthrough();
                 });

            // Add Identity services
            services.AddIdentityCore<IdentityUserEntity>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();
        }
    }
}