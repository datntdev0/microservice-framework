using Abp.Zero.EntityFrameworkCore;
using datntdev.Microservices.Authorization.Roles;
using datntdev.Microservices.Authorization.Users;
using datntdev.Microservices.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace datntdev.Microservices.EntityFrameworkCore;

public class MicroservicesDbContext : AbpZeroDbContext<Tenant, Role, User, MicroservicesDbContext>
{
    /* Define a DbSet for each entity of the application */

    public MicroservicesDbContext(DbContextOptions<MicroservicesDbContext> options)
        : base(options)
    {
    }
}
