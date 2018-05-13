using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PlainCore.Core.DomainModels.Identities;
using PlainCore.Core.DomainModels.Users;
using PlainCore.Core.Externals;
using PlainCore.Core.Externals.Identities;
using PlainCore.Core.Externals.Repositories;
using PlainCore.Core.Helpers.Microsoft.DataTransfer.Basics;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlainCore.WebAPI.Authentication
{
    public class WebApplicationContext : IApplicationContext
    {
        private IUnitOfWork unitOfWork;
        public WebApplicationContext(HttpContext context, IContainer container)
        {
            Guard.NotNull<HttpContext>("HttpContext", context);

            var DataToken = context.User.Claims.Select(x => x.Value).ToArray();
            string applicationUserId = DataToken[0];
            var userManager = container.GetInstance<IIdentityUserManager>();
            unitOfWork = container.GetInstance<IUnitOfWork>();
            this.CurrentApplicationUser = userManager.FindByIdAsync(applicationUserId).Result;
        }

        public ApplicationUser CurrentApplicationUser { get; private set; }
    }
}
