using Microsoft.AspNetCore.Identity;
using System;

namespace datntdev.Microservices.Identity.Application.Authorization.Users
{
    public class IdentityUserEntity : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
