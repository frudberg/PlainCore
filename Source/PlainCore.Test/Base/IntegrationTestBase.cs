using PlainCore.Core.Externals.Identities;
using PlainCore.Core.Externals.Repositories;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Xunit;

namespace PlainCore.Test.Base
{
    [Collection("IntegrationTestsCollection")]
    public class IntegrationTestBase
    {
        public IContainer IoCContainer { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        protected IIdentityUserManager UserManager { get { return this.IoCContainer.GetInstance<IIdentityUserManager>(); } }
        protected readonly string EmptyTenantName = "EmptyTenant";

        public void StartTransaction()
        {
            this.UnitOfWork.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        public void RollbackTransaction()
        {
            this.UnitOfWork.RollbackTransaction();
        }

        public void CommitTransation()
        {
            this.UnitOfWork.CommitTransaction();
        }
    }
}
