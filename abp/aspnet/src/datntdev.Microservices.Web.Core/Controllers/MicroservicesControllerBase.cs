using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace datntdev.Microservices.Controllers
{
    public abstract class MicroservicesControllerBase : AbpController
    {
        protected MicroservicesControllerBase()
        {
            LocalizationSourceName = MicroservicesConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
