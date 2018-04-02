using Microsoft.AspNetCore.Identity;
using PlainCore.Core.DomainModels.Identities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PlainCore.Core.Externals.Identities
{
    public interface IApplicationSignInManager
    {
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task SignOutAsync();
        Task<ClaimsPrincipal> CreateUserPrincipalAsync(ApplicationUser user);
        Task<bool> CanSignInAsync(ApplicationUser user);
    }
}
