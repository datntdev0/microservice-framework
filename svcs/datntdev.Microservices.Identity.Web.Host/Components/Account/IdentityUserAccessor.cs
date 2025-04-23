using Microsoft.AspNetCore.Identity;
using datntdev.Microservices.Identity.Application.Authorization.Users;

namespace datntdev.Microservices.Identity.Web.Host.Components.Account;

internal sealed class IdentityUserAccessor(UserManager<IdentityUserEntity> userManager, IdentityRedirectManager redirectManager)
{
    public async Task<IdentityUserEntity> GetRequiredUserAsync(HttpContext context)
    {
        var user = await userManager.GetUserAsync(context.User);

        if (user is null)
        {
            redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
        }

        return user;
    }
}
