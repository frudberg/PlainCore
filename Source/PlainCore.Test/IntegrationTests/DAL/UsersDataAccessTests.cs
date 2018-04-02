using PlainCore.Test.Base;
using Xunit;
using System.Linq;
using PlainCore.Core.DomainModels.Identities;
using Microsoft.EntityFrameworkCore;

namespace PlainCore.Test.IntegrationTests.DAL
{
    public class UsersDataAccessTests : IntegrationTestBase
    {
        [Fact]
        public void CanCreateNewUser()
        {
            using (var scope = new IntegrationTestScope(this))
            {
                int numberOfUsers = this.UnitOfWork.UsersDBSet.Count();
                var emptyTenant = this.UnitOfWork.TenantsDBSet.Single(x => x.Name == this.EmptyTenantName);
                var applicationUser = new ApplicationUser
                {
                    UserName = "CanCreateNewUser@test.com",
                    Email = "CanCreateNewUser@test.com",
                    EmailConfirmed = true
                };

                this.UserManager.CreateAsync(applicationUser, "Test#123").Wait();
                this.UnitOfWork.UsersDBSet.Add(new Core.DomainModels.Users.User(applicationUser, emptyTenant));
                this.UnitOfWork.SaveChanges();
                Assert.True(this.UnitOfWork.UsersDBSet.Count() == (numberOfUsers +1));
            }
        }

        [Fact]
        public void CanReadUser()
        {
            using (var scope = new IntegrationTestScope(this))
            {
                var user = this.UnitOfWork.UsersDBSet.Where(x => x.ApplicationUser != null).Include(x => x.ApplicationUser).First();
                Assert.True(user.ApplicationUser != null);
            }
        }

        [Fact]
        public void CanUpdateUser()
        {
            using (var scope = new IntegrationTestScope(this))
            {
                var user = this.UnitOfWork.UsersDBSet.Where(x => x.ApplicationUser != null).Include(x => x.ApplicationUser).First();
                user.ApplicationUser.Email = "CanUpdateUser@test.com";
                UnitOfWork.SaveChanges();
                Assert.True(UnitOfWork.UsersDBSet.Any(x => x.ApplicationUser.Email == "CanUpdateUser@test.com"));
            }
        }

        [Fact]
        public void CanDeleteUser()
        {
            using (var scope = new IntegrationTestScope(this))
            {
                var numberOfUsers = this.UnitOfWork.UsersDBSet.Count();
                var user = this.UnitOfWork.UsersDBSet.First(); 
                this.UnitOfWork.UsersDBSet.Remove(user);
                this.UnitOfWork.SaveChanges();
                Assert.True(UnitOfWork.UsersDBSet.Count() == (numberOfUsers - 1));
            }
        }
    }
}
