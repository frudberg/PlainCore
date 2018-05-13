using PlainCore.Core.CQS.Base;
using PlainCore.Core.DomainModels.Identities;
using PlainCore.Core.Externals.Identities;
using PlainCore.Core.Externals.Repositories;
using PlainCore.Core.Helpers.Microsoft.DataTransfer.Basics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainCore.Core.CQS.Users
{
    public class CreateUserCommandHandler : AbstractCommandHandler<CreateUserCommand>
    {
        private IUnitOfWork unitOfWork;
        private IIdentityUserManager userManager;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IIdentityUserManager userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        public async override Task<CommandResult> ExecuteAsync(CreateUserCommand command)
        {
            Guard.NotNull<CreateUserCommand>("CreateUserCommand", command);

            var applicationUser = new ApplicationUser
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                UserName = command.Username,
                Email = command.Username,
                EmailConfirmed = command.EmailConfirmed
            };

            await userManager.CreateAsync(applicationUser, command.Password);
            await this.unitOfWork.UsersDBSet.AddAsync(new DomainModels.Users.User(applicationUser,command.TenantID));
            await this.unitOfWork.SaveChangesAsync();
            return await base.ExecuteAsync(command);
        }
    }
}
