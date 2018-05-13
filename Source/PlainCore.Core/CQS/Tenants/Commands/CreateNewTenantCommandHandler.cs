using PlainCore.Core.CQS.Base;
using PlainCore.Core.Externals.Repositories;
using PlainCore.Core.Helpers.Microsoft.DataTransfer.Basics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainCore.Core.CQS.Tenants.Commands
{
    public class CreateNewTenantCommandHandler : AbstractCommandHandler<CreateNewTenantCommand>
    {
        private IUnitOfWork unitOfWork;

        public CreateNewTenantCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async override Task<CommandResult> ExecuteAsync(CreateNewTenantCommand command)
        {
            Guard.NotNull<CreateNewTenantCommand>("CreateNewTenantCommand", command);

            await this.unitOfWork.TenantsDBSet.AddAsync(new DomainModels.Tenants.Tenant() { Name = command.Name });
            await this.unitOfWork.SaveChangesAsync();
            return await base.ExecuteAsync(command);
        }
    }
}
