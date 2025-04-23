using datntdev.Microservices.Identity.Application.Authorization.Roles;
using datntdev.Microservices.Identity.Application.Authorization.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace datntdev.Microservices.Identity.Application.Authorization.Users;

public class ApplicationDbContext : IdentityDbContext<IdentityUserEntity, IdentityRoleEntity, Guid>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}
