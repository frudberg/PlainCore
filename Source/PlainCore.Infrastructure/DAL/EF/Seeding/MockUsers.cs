using Microsoft.EntityFrameworkCore;
using PlainCore.Core.DomainModels.Identities;
using PlainCore.Core.DomainModels.Tenants;
using PlainCore.Core.DomainModels.Users;
using PlainCore.Core.Externals.Identities;
using PlainCore.Core.Externals.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PlainCore.Infrastructure.DAL.EF.Seeding
{
    public static class MockUsers
    {
        public static void CreateUsers(IUnitOfWork unitOfWork, IIdentityUserManager userManager)
        {
            Dictionary<Tenant,ApplicationUser> userTenants = new Dictionary<Tenant, ApplicationUser>();
            foreach(var tenant in unitOfWork.TenantsDBSet.Where(x => x.Name != "EmptyTenant").Include(x => x.Users).ToList())
            {
                var applicationUser = CreateApplicationUser($"{tenant.Name}_FirstName", $"{tenant.Name}_LastName", $"{tenant.Name}_User1@plaincore.org","PlainCore100",true,userManager);
                userTenants.Add(tenant, applicationUser);
            }
            unitOfWork.SaveChanges();

            foreach (var item in userTenants)
            {
                CreateUser(unitOfWork, userManager.FindByNameAsync(item.Value.Email).Result, item.Key);
            }

            unitOfWork.SaveChanges();
        }
        private static ApplicationUser CreateApplicationUser(string firstname, string lastname, string name, string password, bool emailConfirmed, IIdentityUserManager userManager)
        {
            var email = name;
            ApplicationUser applicationUser;

            applicationUser = new ApplicationUser
            {
                FirstName = firstname,
                LastName = lastname,
                UserName = email,
                Email = email,
                EmailConfirmed = emailConfirmed
            };

            if (!string.IsNullOrEmpty(password))
            {
                userManager.CreateAsync(applicationUser, password).Wait();
            }
            else
            {
                userManager.CreateAsync(applicationUser).Wait();
            }

            return applicationUser;
        }

        private static void CreateUser(IUnitOfWork unitOfWork, ApplicationUser applicationUser, Tenant tenant)
        {
            unitOfWork.UsersDBSet.Add(new User(applicationUser, tenant));
        }
    }
}
