using PlainCore.Core.DomainModels.Identities;
using PlainCore.Core.DomainModels.Tenants;
using PlainCore.Core.DomainModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Core.Externals
{
    public interface IApplicationContext
    {
        ApplicationUser CurrentApplicationUser { get; }
    }
}
