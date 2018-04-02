using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainCore.Core.CQS.Base
{
    public abstract class AbstractValidationHandler<T> : AbstractValidator<T>, IValidationHandler<T> where T : ICommand
    {
        public new ValidationResult Validate(T command)
        {
            return new ValidationResult(base.Validate(command));
        }
    }
}
