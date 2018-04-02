using PlainCore.Core.CQS.Base;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace PlainCore.Core.CQS.Tenants.Commands
{
    public class CreateNewTenantValidationHandler : AbstractValidationHandler<CreateNewTenantCommand>
    {
        public CreateNewTenantValidationHandler()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be null");
        }
    }
}
