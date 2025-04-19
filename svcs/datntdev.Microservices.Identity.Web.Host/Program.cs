using datntdev.Microservices.ServiceDefaults.Hosting;
using datntdev.Microservices.Identity.Web.Host;
using Microsoft.Extensions.Options;
using datntdev.Microservices.Identity.Web.Host.Services;

ServiceBootstrapBuilder.CreateWebApplication<Startup>(args).Run();

public class Startup(IWebHostEnvironment env) : ServiceStartup(env)
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddServiceBootstrap<IdentityWebHostModule>(_hostingConfiguration);

        services.AddControllersWithViews();
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddDefaultOpenTelemetry(_hostingEnvironment, _hostingConfiguration);
        services.AddDefaultServiceDiscovery();
        services.AddHostedService<Worker>();
    }

    public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseServiceBootstrap<IdentityWebHostModule>(_hostingConfiguration);

        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseForwardedHeaders();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(configure =>
        {
            configure.MapControllers();
            configure.MapDefaultControllerRoute();
            configure.MapStaticAssets();
            configure.MapRazorPages().WithStaticAssets();
            configure.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();
        });
    }
}
