using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using datntdev.Microservices.Authorization;

namespace datntdev.Microservices;

[DependsOn(
    typeof(MicroservicesCoreModule),
    typeof(AbpAutoMapperModule))]
public class MicroservicesApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<MicroservicesAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(MicroservicesApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }
}
