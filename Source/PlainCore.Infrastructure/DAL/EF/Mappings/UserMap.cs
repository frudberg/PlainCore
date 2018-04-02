using Microsoft.EntityFrameworkCore;
using PlainCore.Core.DomainModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Infrastructure.DAL.EF.Mappings
{
    public static class UserMap
    {
        public static ModelBuilder MapUser(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<User>();
            entity.ToTable("Users");
            entity.Property(c => c.Id).ValueGeneratedOnAdd();
            entity.HasOne(c => c.ApplicationUser).WithMany(x => x.Users).HasForeignKey(x => x.ApplicationUserId);
            entity.Property(c => c.CreatedDate);
            entity.Property(c => c.UpdatedDate);
            return modelBuilder;
        }
    }
}
