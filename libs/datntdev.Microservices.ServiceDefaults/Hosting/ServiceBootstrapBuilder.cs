using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace datntdev.Microservices.ServiceDefaults.Hosting
{
    public static class ServiceBootstrapBuilder
    {
        public static IHostBuilder Create<TStartup>(string[] args) where TStartup : ServiceStartup
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<TStartup>();
                });
        }
    }
}
