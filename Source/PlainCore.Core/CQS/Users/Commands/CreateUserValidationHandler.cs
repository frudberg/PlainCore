using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PlainCore.Core.CQS.Base;
using PlainCore.Core.Resources;

namespace PlainCore.Core.CQS.Users
{
    public class CreateUserValidationHandler : AbstractValidationHandler<CreateUserCommand>
    {
        public CreateUserValidationHandler(LocalizationService localization)
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(localization.GetLocalizedHtmlString("VALIDATION_FIRSTNAME_NOT_NULL"));
            RuleFor(x => x.LastName).NotEmpty().WithMessage(localization.GetLocalizedHtmlString("VALIDATION_LASTNAME_NOT_NULL"));
            RuleFor(x => x.Password).NotEmpty().WithMessage(localization.GetLocalizedHtmlString("VALIDATION_PASSWORD_NOT_NULL"));
            RuleFor(x => x.Username).NotEmpty().WithMessage(localization.GetLocalizedHtmlString("VALIDATION_USERNAME_NOT_NULL"));
            RuleFor(x => x.TenantID).NotNull().WithMessage(localization.GetLocalizedHtmlString("VALIDATION_TENANTID_NOT_NULL"));
        }
    }
}