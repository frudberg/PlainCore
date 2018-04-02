using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using PlainCore.Core.DomainModels.Base;
using PlainCore.Core.DomainModels.Identities;
using PlainCore.Core.DomainModels.Tenants;
using PlainCore.Core.DomainModels.Users;
using PlainCore.Core.Externals.Repositories;
using PlainCore.Infrastructure.DAL.EF.Mappings;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlainCore.Infrastructure.DAL.EF
{
    public class UnitOfWork : IdentityDbContext<ApplicationUser>, IUnitOfWork
    {
        private IDbContextTransaction transaction;

        public DbSet<User> UsersDBSet { get; set; }
        public DbSet<Tenant> TenantsDBSet { get; set; }
        public DbSet<ApplicationRole> ApplicationRoleDBSet { get; set; }
        public IQueryable<User> UserQuery {get {return this.UsersDBSet;} }
        public IQueryable<Tenant> TenantQuery { get { return this.TenantsDBSet;} }

        public UnitOfWork()
        {

        }

        public UnitOfWork(DbContextOptions options) : base(options)
        {

        }

        public override int SaveChanges()
        {
            AddEntityData();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.MapUser();
            builder.MapTenant();
            builder.UseOpenIddict();
            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddEntityData();
            return base.SaveChangesAsync(cancellationToken);
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (transaction == null)
            {
                transaction = this.Database.BeginTransaction(isolationLevel);
            }
        }

        public void RollbackTransaction()
        {
            if (transaction != null)
            {
                transaction.Rollback();
                transaction = null;
            }
        }

        public virtual void CommitTransaction()
        {
            if (transaction != null)
            {
                transaction.Commit();
                transaction = null;
            }
        }


        private void AddEntityData()
        {
            if (this.ChangeTracker != null && this.ChangeTracker.Entries() != null)
            {
                var entities = this.ChangeTracker.Entries().Where(x => x.Entity is EntityBase<Guid> && (x.State == EntityState.Added || x.State == EntityState.Modified)).ToList();

                foreach (var entity in entities)
                {
                    if (entity.State == EntityState.Added)
                    {
                        ((EntityBase<Guid>)entity.Entity).CreatedDate = DateTime.UtcNow;
                        ((EntityBase<Guid>)entity.Entity).UpdatedDate = DateTime.UtcNow;
                    }
                    else
                        ((EntityBase<Guid>)entity.Entity).UpdatedDate = DateTime.UtcNow;
                }
            }
        }
    }
}
