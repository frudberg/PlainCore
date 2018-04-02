using PlainCore.Core.CQS.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainCore.Core.Externals.Dispatcher
{
    public interface ICommandBus
    {
        CommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand;
        Task<CommandResult> SubmitAsync<TCommand>(TCommand command) where TCommand : ICommand;
        ValidationResult Validate<TCommand>(TCommand command) where TCommand : ICommand;
        Task<ValidationResult> ValidateAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
