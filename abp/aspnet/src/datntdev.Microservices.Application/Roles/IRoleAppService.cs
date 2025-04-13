using Abp.Application.Services;
using Abp.Application.Services.Dto;
using datntdev.Microservices.Roles.Dto;
using System.Threading.Tasks;

namespace datntdev.Microservices.Roles;

public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>
{
    Task<ListResultDto<PermissionDto>> GetAllPermissions();

    Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);

    Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input);
}
