using datntdev.Microservices.Common.Modular;
using datntdev.Microservices.Identity.Application;

namespace datntdev.Microservices.Identity.Web.Host
{
    [DependOn(typeof(IdentityApplicationModule))]
    public class IdentityWebHostModule : BaseModule
    {
    }
}
