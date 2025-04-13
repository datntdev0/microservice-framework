using Abp.MultiTenancy;
using datntdev.Microservices.Authorization.Users;

namespace datntdev.Microservices.MultiTenancy;

public class Tenant : AbpTenant<User>
{
    public Tenant()
    {
    }

    public Tenant(string tenancyName, string name)
        : base(tenancyName, name)
    {
    }
}
