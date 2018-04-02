using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using StructureMap;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PlainCore.Infrastructure.DAL.EF.Seeding;
using PlainCore.Core.Externals.Identities;

namespace PlainCore.Infrastructure.DAL.EF
{
    public static class DBContextExtensions
    {
        public static bool AllMigrationsApplied(this UnitOfWork context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this UnitOfWork context, IContainer container)
        {
            if (!context.TenantsDBSet.Any())
            {
                MockTenants.CreateTenants(context);
            }

            if(!context.UsersDBSet.Any())
            {
                MockUsers.CreateUsers(context, container.GetInstance<IIdentityUserManager>());
            }
        }
    }
}
