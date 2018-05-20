using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Core.DomainModels.UserRoles
{
    public abstract class AbstractUserRole
    {
        public abstract bool CanManageUsers { get; protected set; }
        public abstract bool CanReadUsers { get; protected set; }
        public abstract bool CanManageTenants { get; protected set; }
        public abstract bool CanReadTenants { get; protected set; }
    }

    public class TenantAdministrator : AbstractUserRole
    {
        public override bool CanManageUsers { get; protected set; } = true;
        public override bool CanReadUsers { get; protected set; } = true;
        public override bool CanReadTenants { get; protected set; } = false;
        public override bool CanManageTenants { get; protected set; } = false;
    }

    public class TenantUser : AbstractUserRole
    {
        public override bool CanManageUsers { get; protected set; } = false;
        public override bool CanReadUsers { get; protected set; } = true;
        public override bool CanReadTenants { get; protected set; } = false;
        public override bool CanManageTenants { get; protected set; } = true;
    }
}
