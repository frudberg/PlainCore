using Microsoft.AspNetCore.Identity;
using PlainCore.Core.DomainModels.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlainCore.Core.Externals.Identities
{
    public interface IIdentityRoleManager
    {
        Task<IdentityResult> CreateAsync(ApplicationRole role);
        Task<IdentityResult> UpdateAsync(ApplicationRole role);
        Task<IdentityResult> DeleteAsync(ApplicationRole role);
        Task<ApplicationRole> FindByIdAsync(string roleId);
        IQueryable<ApplicationRole> Roles { get; }
    }
}
