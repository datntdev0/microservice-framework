using datntdev.Microservices.Common.Modular;
using datntdev.Microservices.Identity.Contracts;

namespace datntdev.Microservices.Identity.Application
{
    [DependOn(typeof(IdentityContractsModule))]
    public class IdentityApplicationModule : BaseModule
    {
    }
}