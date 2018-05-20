using PlainCore.Core.DomainModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Core.DomainModels.UserRoles
{
    public static class UserRoleFactory
    {
        public static AbstractUserRole GetRoleFromRoleUser(UserRole userRole)
        {
            if (userRole == UserRole.TenantAdministrator)
                return new TenantAdministrator();
            else if (userRole == UserRole.TenantUser)
                return new TenantUser();
            else
                return null;
        }
    }
}
