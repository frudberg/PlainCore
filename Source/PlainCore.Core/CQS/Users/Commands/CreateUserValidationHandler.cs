using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PlainCore.Core.CQS.Base;

namespace PlainCore.Core.CQS.Users
{
    public class CreateUserValidationHandler : AbstractValidationHandler<CreateUserCommand>
    {
        public CreateUserValidationHandler()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName cannot be null");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName cannot be null");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be null");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be null");
            RuleFor(x => x.TenantID).NotNull().WithMessage("TenantID cannot be null");
        }
    }
}