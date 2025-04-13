using datntdev.Microservices.Configuration.Dto;
using System.Threading.Tasks;

namespace datntdev.Microservices.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
