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
    public class ApplicationUserStoreDecorator : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
    {
        private UserStore<ApplicationUser> userStore;

        public ApplicationUserStoreDecorator(IUnitOfWork unitOfWork)
        {
            userStore = new UserStore<ApplicationUser>((UnitOfWork)unitOfWork);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await userStore.CreateAsync(user, cancellationToken);
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await userStore.DeleteAsync(user, cancellationToken);
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return await userStore.FindByIdAsync(userId,cancellationToken);
        }

        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return await userStore.FindByNameAsync(normalizedUserName, cancellationToken);
        }

        public async Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await userStore.GetNormalizedUserNameAsync(user, cancellationToken);
        }

        public async Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await userStore.GetPasswordHashAsync(user, cancellationToken);
        }

        public async Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await userStore.GetUserIdAsync(user, cancellationToken);
        }

        public async Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await userStore.GetUserNameAsync(user, cancellationToken);
        }

        public async Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await userStore.HasPasswordAsync(user, cancellationToken);
        }

        public async Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            await userStore.SetNormalizedUserNameAsync(user, normalizedName,cancellationToken);
        }

        public async Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            await userStore.SetPasswordHashAsync(user, passwordHash, cancellationToken);
        }

        public async Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            await userStore.SetUserNameAsync(user, userName, cancellationToken);
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await userStore.UpdateAsync(user, cancellationToken);
        }

        public void Dispose()
        {
            userStore.Dispose();
        }
    }
}
