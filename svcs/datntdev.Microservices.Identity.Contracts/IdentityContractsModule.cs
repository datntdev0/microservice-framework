using datntdev.Microservices.Common.Modular;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace datntdev.Microservices.Identity.Contracts
{
    public class IdentityContractsModule(IServiceProvider serviceProvider) : BaseModule(serviceProvider)
    {
        public override void PreInitialize()
        {
            base.PreInitialize();
            _logger.LogInformation($"{nameof(IdentityContractsModule)} PreInitialize");
        }
    }
}
