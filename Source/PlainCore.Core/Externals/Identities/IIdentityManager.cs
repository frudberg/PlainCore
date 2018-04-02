using Microsoft.AspNetCore.Identity;
using PlainCore.Core.DomainModels.Identities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PlainCore.Core.Externals.Identities
{
    public interface IIdentityUserManager : IIdentityUserManagerRead
    {
        bool SupportsUserLockout { get; }
        Task<ApplicationUser> FindByIdAsync(string userId);
        Task<ApplicationUser> FindByNameAsync(string userName);
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<IList<string>> GetRolesAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserAsync(ClaimsPrincipal principal);
        Task<bool> HasPasswordAsync(ApplicationUser user);
        Task<bool> IsEmailConfirmedAsync(ApplicationUser user);
        Task<IdentityResult> CreateAsync(ApplicationUser user, string password);
        Task<IdentityResult> CreateAsync(ApplicationUser user);
        Task<IdentityResult> SetLockoutEnabledAsync(ApplicationUser user, bool enabled);
        Task<IdentityResult> AccessFailedAsync(ApplicationUser user);
        Task<IdentityResult> ResetAccessFailedCountAsync(ApplicationUser user);
        //Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser user, IEnumerable<string> scopes);
        Task<IdentityResult> RemoveAuthenticationTokenAsync(ApplicationUser user, string loginProvider, string tokenName);
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
        Task<IdentityResult> DeleteAsync(ApplicationUser user);
        Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token);
        Task<IdentityResult> AddPasswordAsync(ApplicationUser user, string password);
    }

    public interface IIdentityUserManagerRead
    {

    }
}
