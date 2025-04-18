using datntdev.Microservices.Common.Modular;
using datntdev.Microservices.Identity.Application.Authorization.Users;
using datntdev.Microservices.Identity.Contracts;
using datntdev.Microservices.Identity.Web.Host.Data;
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // Add Identity services
            services.AddDefaultIdentity<IdentityUserEntity>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}