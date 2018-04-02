using Microsoft.EntityFrameworkCore;
using PlainCore.Core.DomainModels.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Infrastructure.DAL.EF.Mappings
{
    public static class TenantMap
    {
        public static ModelBuilder MapTenant(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Tenant>();
            entity.ToTable("Tenants");
            entity.Property(c => c.Id).ValueGeneratedOnAdd();
            entity.HasMany(c => c.Users).WithOne(c => c.Tenant).HasForeignKey(x => x.TenantId);
            entity.Property(c => c.CreatedDate);
            entity.Property(c => c.UpdatedDate);
            return modelBuilder;
        }
    }   
}
