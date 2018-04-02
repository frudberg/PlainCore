using PlainCore.Test.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace PlainCore.Test.IntegrationTests.DAL
{
    public class AccountDataAccessTests : IntegrationTestBase
    {

        [Fact]
        public void CanCreateNewAccount()
        {
            using (var scope = new IntegrationTestScope(this))
            {
                int numberOfAccounts = this.UnitOfWork.TenantsDBSet.Count();
                this.UnitOfWork.TenantsDBSet.Add(new Core.DomainModels.Tenants.Tenant()
                {
                    CreatedDate = DateTime.Now,
                    Name = "MyTestAccount"
                });

                this.UnitOfWork.SaveChanges();
                Assert.True(this.UnitOfWork.TenantsDBSet.Count() == (numberOfAccounts + 1));
            }
        }

        [Fact]
        public void CanReadAccount()
        {
            using (var scope = new IntegrationTestScope(this))
            {
                var accounts = this.UnitOfWork.TenantsDBSet.ToList();
                Assert.True(accounts.Count() > 0);
            }
        }

        [Fact]
        public void CanUpdateAccount()
        {
            string newName = "CanUpdateAccount_Account";
            using (var scope = new IntegrationTestScope(this))
            {
                var account = this.UnitOfWork.TenantsDBSet.Where(x => x.Users.Count() == 0).First();
                account.Name = newName;
                account.Users.Add(this.UnitOfWork.UsersDBSet.First());
                this.UnitOfWork.SaveChanges();
                Assert.True(this.UnitOfWork.TenantsDBSet.Where(x => x.Name == newName).Single().Users.Count() == 1);
            }
        }

        [Fact]
        public void CanDeleteAccount()
        {
            using (var scope = new IntegrationTestScope(this))
            {
                var numberOfUsers = this.UnitOfWork.UsersDBSet.Count();
                var testTenant1 = this.UnitOfWork.TenantsDBSet.Single(x => x.Name == "TestTenant1");
                this.UnitOfWork.TenantsDBSet.Remove(testTenant1);
                this.UnitOfWork.SaveChanges();
                Assert.True(this.UnitOfWork.TenantsDBSet.SingleOrDefault(x => x.Name == "TestTenant1") == null);
                Assert.True(this.UnitOfWork.UsersDBSet.Count() < numberOfUsers);
            }
        }
    }
}
