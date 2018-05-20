using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using PlainCore.Core.Externals.Identities;
using PlainCore.Core.Externals.Repositories;
using PlainCore.Core.Helpers.UOWExtensions;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PlainCore.WebAPI.Authentication
{
    public enum Permission
    {
        CanManageUsers,
        CanReadUsers, 
        CanManageTenants,
        CanReadTenants
    }

    public class RolePermissionFilter : Attribute, IAsyncAuthorizationFilter
    {
        private readonly IContainer container;
        private readonly Permission[] permissions;

        public RolePermissionFilter(IContainer container, Permission[] permissions)
        {
            this.permissions = permissions;
            this.container = container;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var claimsIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
            if (context.HttpContext.User.Identity.IsAuthenticated && claimsIdentity != null)
            {
                var appUserId = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                var applicationUser = await container.GetInstance<IIdentityUserManager>().FindByIdAsync(appUserId);
                if (applicationUser == null)
                    context.Result = new ChallengeResult(JwtBearerDefaults.AuthenticationScheme);

                else if (!applicationUser.IsSuperAdministrator)
                {
                    bool result = true;
                    var user = await container.GetInstance<IUnitOfWork>().UsersDBSet.GetUserByAppIdIncludeAppUser(appUserId);

                    foreach (var permission in permissions)
                    {
                        if (result)
                            result = (bool)user.UserRoleObject.GetType().GetProperty(permission.ToString()).GetValue(user.UserRoleObject, null);
                    }

                    if (!result)
                        context.Result = new ChallengeResult(JwtBearerDefaults.AuthenticationScheme);
                }
            }
            else
                context.Result = new ChallengeResult(JwtBearerDefaults.AuthenticationScheme);
        }

        public class AuthorizePermissionAttribute : TypeFilterAttribute
        {
            public AuthorizePermissionAttribute(params Permission[] permissions)
                  : base(typeof(RolePermissionFilter))
            {
                Arguments = new[] { permissions };
                Order = Int32.MaxValue;
            }
        }
    }
}
