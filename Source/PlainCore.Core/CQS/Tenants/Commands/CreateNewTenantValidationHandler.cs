using PlainCore.Core.CQS.Base;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using PlainCore.Core.Resources;

namespace PlainCore.Core.CQS.Tenants.Commands
{
    public class CreateNewTenantValidationHandler : AbstractValidationHandler<CreateNewTenantCommand>
    {
        public CreateNewTenantValidationHandler(LocalizationService localization)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localization.GetLocalizedHtmlString("VALIDATION_NAME_NOT_NULL"));
        }
    }
}
