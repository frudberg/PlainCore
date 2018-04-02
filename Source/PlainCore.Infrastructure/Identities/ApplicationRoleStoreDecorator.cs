using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PlainCore.Core.DomainModels.Identities;
using PlainCore.Core.Externals.Repositories;
using PlainCore.Infrastructure.DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlainCore.Infrastructure.Identities
{
    public class ApplicationRoleStoreDecorator : IRoleStore<ApplicationRole>
    {
        private IRoleStore<ApplicationRole> roleStore;
        public ApplicationRoleStoreDecorator(IUnitOfWork unitOfWork)
        {
            roleStore = new RoleStore<ApplicationRole>((UnitOfWork)unitOfWork);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return await roleStore.CreateAsync(role, cancellationToken);
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return await roleStore.DeleteAsync(role, cancellationToken);
        }

        public async Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return await roleStore.FindByIdAsync(roleId, cancellationToken);
        }

        public async Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return await roleStore.FindByNameAsync(normalizedRoleName, cancellationToken);
        }

        public async Task<string> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return await roleStore.GetNormalizedRoleNameAsync(role, cancellationToken);
        }

        public async Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return await roleStore.GetRoleIdAsync(role, cancellationToken);
        }

        public async Task<string> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return await roleStore.GetRoleNameAsync(role, cancellationToken);
        }

        public async Task SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken)
        {
            await roleStore.SetNormalizedRoleNameAsync(role, normalizedName, cancellationToken);
        }

        public async Task SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken)
        {
            await roleStore.SetRoleNameAsync(role, roleName, cancellationToken);
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return await roleStore.UpdateAsync(role, cancellationToken);
        }

        public void Dispose()
        {
            roleStore.Dispose();
        }
    }
}
