using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PlainCore.Core.DomainModels.Identities;
using PlainCore.Core.Externals.Identities;
using PlainCore.Infrastructure.DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Primitives;

namespace PlainCore.Infrastructure.Identities
{
    public class ApplicationUserManager : UserManager<ApplicationUser>, IIdentityUserManager
    {
        public ApplicationUserManager(
            IServiceProvider services,
            IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> options,
            ILogger<UserManager<ApplicationUser>> logger,
            IPasswordHasher<ApplicationUser> hasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors
            ) : base(store, options, hasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
                { }
    }
}
