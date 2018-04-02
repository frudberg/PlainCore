using PlainCore.Core.DomainModels.Tenants;
using PlainCore.Core.Externals.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Infrastructure.DAL.EF.Seeding
{
    public static class MockTenants
    {
        public static void CreateTenants(IUnitOfWork unitOfwork)
        {
            unitOfwork.TenantsDBSet.Add(CreateTenant("TestTenant1"));
            unitOfwork.TenantsDBSet.Add(CreateTenant("TestTenant2"));
            unitOfwork.TenantsDBSet.Add(CreateTenant("TestTenant3"));
            unitOfwork.TenantsDBSet.Add(CreateTenant("TestTenant4"));
            unitOfwork.TenantsDBSet.Add(CreateTenant("TestTenant5"));
            unitOfwork.TenantsDBSet.Add(CreateTenant("EmptyTenant"));
            unitOfwork.SaveChanges();
        }
        public static Tenant CreateTenant(string name)
        {
            var tenant = new Tenant()
            {
                Name = name
            };
            return tenant;
        }
    }
}
