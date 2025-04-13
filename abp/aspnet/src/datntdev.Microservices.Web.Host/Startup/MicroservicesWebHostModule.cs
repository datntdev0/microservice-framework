using Abp.Modules;
using Abp.Reflection.Extensions;
using datntdev.Microservices.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace datntdev.Microservices.Web.Host.Startup
{
    [DependsOn(
       typeof(MicroservicesWebCoreModule))]
    public class MicroservicesWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MicroservicesWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MicroservicesWebHostModule).GetAssembly());
        }
    }
}
