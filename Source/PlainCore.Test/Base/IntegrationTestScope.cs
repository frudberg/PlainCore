using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using PlainCore.Core.Externals.Repositories;
using PlainCore.Infrastructure.DAL.EF;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Test.Base
{

    public class IntegrationTestScope : IDisposable
    {
        private IntegrationTestBase uat;
        private bool commitChanges;
        public IntegrationTestScope(IntegrationTestBase uat, bool commitChanges = false)
        {
            this.commitChanges = commitChanges;
            this.uat = uat;

            var Server = new TestServer(new WebHostBuilder().UseStartup<TestServerStartup>());
            uat.IoCContainer = Server.Host.Services.GetService(typeof(IContainer)) as IContainer;
            UnitOfWork unitOfWorkTemp = (uat.UnitOfWork = uat.IoCContainer.GetInstance<IUnitOfWork>()) as UnitOfWork;

            if (!unitOfWorkTemp.AllMigrationsApplied())
            {
                unitOfWorkTemp.Database.Migrate();
                unitOfWorkTemp.EnsureSeeded(uat.IoCContainer);
            }

            if (commitChanges == false)
                uat.StartTransaction();
        }

        public void Dispose()
        {
            if (commitChanges == false)
                uat.RollbackTransaction();
        }
    }
}
