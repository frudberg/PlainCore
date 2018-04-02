using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainCore.Core.CQS.Base
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        ValidationResult Validate(TCommand command);
        //Task<ValidationResult> ValidateAsync(TCommand command);
    }
}
