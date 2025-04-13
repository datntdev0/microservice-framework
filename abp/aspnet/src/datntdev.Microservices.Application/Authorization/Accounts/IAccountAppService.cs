using Abp.Application.Services;
using datntdev.Microservices.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace datntdev.Microservices.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
