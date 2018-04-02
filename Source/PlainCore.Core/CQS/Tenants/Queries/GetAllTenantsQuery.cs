using PlainCore.Core.CQS.Base;
using PlainCore.Core.DomainModels.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Core.CQS.Tenants.Queries
{
    public class GetAllTenantsQuery : IQuery<IList<TenantDTO>>
    {
    }
}
