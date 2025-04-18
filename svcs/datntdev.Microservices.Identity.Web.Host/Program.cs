using datntdev.Microservices.ServiceDefaults.Hosting;
using datntdev.Microservices.Identity.Web.Host;

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
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(configure =>
        {
            configure.MapStaticAssets();
            configure.MapRazorPages().WithStaticAssets();
            configure.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();
        });
    }
}
