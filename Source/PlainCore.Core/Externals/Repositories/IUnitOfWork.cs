using Microsoft.EntityFrameworkCore;
using PlainCore.Core.DomainModels.Tenants;
using PlainCore.Core.DomainModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlainCore.Core.Externals.Repositories
{
    public interface IUnitOfWork
    {
        DbSet<User> UsersDBSet { get; set; }
        DbSet<Tenant> TenantsDBSet { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        void BeginTransaction(System.Data.IsolationLevel isolationLevel = System.Data.IsolationLevel.ReadCommitted);
        void RollbackTransaction();
        void CommitTransaction();
        int SaveChanges();
    }
}
