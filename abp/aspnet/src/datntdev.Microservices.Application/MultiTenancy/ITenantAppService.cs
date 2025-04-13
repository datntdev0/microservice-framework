using Abp.Application.Services;
using datntdev.Microservices.MultiTenancy.Dto;

namespace datntdev.Microservices.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

