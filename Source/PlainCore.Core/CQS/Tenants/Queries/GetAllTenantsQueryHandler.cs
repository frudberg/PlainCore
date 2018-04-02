using PlainCore.Core.CQS.Base;
using PlainCore.Core.DomainModels.Tenants;
using PlainCore.Core.Externals.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PlainCore.Core.CQS.Tenants.Queries
{
    public class GetAllTenantsQueryHandler : IQueryHandler<GetAllTenantsQuery, IList<TenantDTO>>
    {
        private IUnitOfWork unitOfWork;

        public GetAllTenantsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IList<TenantDTO> Handle(GetAllTenantsQuery query)
        {
            return this.unitOfWork.TenantsDBSet.Include(x => x.Users).Select(x => x.ToTenantDTO()).ToList();
        }
    }
}
