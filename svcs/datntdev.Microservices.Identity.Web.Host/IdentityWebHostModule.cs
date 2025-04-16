using datntdev.Microservices.Common.Modular;
using datntdev.Microservices.Identity.Application;

namespace datntdev.Microservices.Identity.Web.Host
{
    [DependOn(typeof(IdentityApplicationModule))]
    public class IdentityWebHostModule(IServiceProvider serviceProvider) : BaseModule(serviceProvider)
    {
        public override void PreInitialize()
        {
            base.PreInitialize();
            _logger.LogInformation($"{nameof(IdentityWebHostModule)} PreInitialize");
        }
    }
}
