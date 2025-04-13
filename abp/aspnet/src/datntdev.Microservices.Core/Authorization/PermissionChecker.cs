using Abp.Authorization;
using datntdev.Microservices.Authorization.Roles;
using datntdev.Microservices.Authorization.Users;

namespace datntdev.Microservices.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
