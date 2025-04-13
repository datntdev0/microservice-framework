using Abp.Authorization;
using Abp.Runtime.Session;
using datntdev.Microservices.Configuration.Dto;
using System.Threading.Tasks;

namespace datntdev.Microservices.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : MicroservicesAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
