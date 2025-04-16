using datntdev.Microservices.Common.Modular;
using datntdev.Microservices.Identity.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace datntdev.Microservices.Identity.Application
{
    [DependOn(typeof(IdentityContractsModule))]
    public class IdentityApplicationModule(IServiceProvider serviceProvider) : BaseModule(serviceProvider)
    {
        public override void PreInitialize()
        {
            base.PreInitialize();
            _logger.LogInformation($"{nameof(IdentityApplicationModule)} PreInitialize");
        }
    }
}