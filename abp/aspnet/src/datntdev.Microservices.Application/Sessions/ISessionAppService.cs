using Abp.Application.Services;
using datntdev.Microservices.Sessions.Dto;
using System.Threading.Tasks;

namespace datntdev.Microservices.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
