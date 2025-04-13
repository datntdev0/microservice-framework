using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using datntdev.Microservices.EntityFrameworkCore;
using datntdev.Microservices.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace datntdev.Microservices.Web.Tests;

[DependsOn(
    typeof(MicroservicesWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class MicroservicesWebTestModule : AbpModule
{
    public MicroservicesWebTestModule(MicroservicesEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(MicroservicesWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(MicroservicesWebMvcModule).Assembly);
    }
}