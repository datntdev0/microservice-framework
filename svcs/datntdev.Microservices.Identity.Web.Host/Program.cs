using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using datntdev.Microservices.Identity.Web.Host.Components;
using datntdev.Microservices.Identity.Web.Host.Components.Account;
using datntdev.Microservices.ServiceDefaults.Hosting;
using datntdev.Microservices.Identity.Web.Host;
using datntdev.Microservices.Identity.Application.Authorization.Users;

ServiceBootstrapBuilder.CreateWebApplication<Startup>(args).Run();

internal class Startup(IWebHostEnvironment env) : ServiceStartup(env)
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddServiceBootstrap<IdentityWebHostModule>(_hostingConfiguration);

        services.AddRazorComponents()
            .AddInteractiveServerComponents();

        services.AddCascadingAuthenticationState();
        services.AddScoped<IdentityUserAccessor>();
        services.AddScoped<IdentityRedirectManager>();
        services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        }).AddIdentityCookies();

        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddSingleton<IEmailSender<IdentityUserEntity>, IdentityNoOpEmailSender>();
    }

    public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseServiceBootstrap<IdentityWebHostModule>(_hostingConfiguration);


        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAntiforgery();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(configure =>
        {
            configure.MapAdditionalIdentityEndpoints();
            configure.MapRazorComponents<App>().AddInteractiveServerRenderMode();
            configure.MapStaticAssets();
        });
    }
}
