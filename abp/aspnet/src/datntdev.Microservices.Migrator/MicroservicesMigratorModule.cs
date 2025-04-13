using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using datntdev.Microservices.Configuration;
using datntdev.Microservices.EntityFrameworkCore;
using datntdev.Microservices.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace datntdev.Microservices.Migrator;

[DependsOn(typeof(MicroservicesEntityFrameworkModule))]
public class MicroservicesMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public MicroservicesMigratorModule(MicroservicesEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(MicroservicesMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            MicroservicesConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(MicroservicesMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
