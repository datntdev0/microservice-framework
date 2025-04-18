using datntdev.Microservices.Identity.Application.Authorization.Roles;
using datntdev.Microservices.Identity.Application.Authorization.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace datntdev.Microservices.Identity.Web.Host.Data;

internal class ApplicationDbContext : IdentityDbContext<IdentityUserEntity, IdentityRoleEntity, Guid>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}
