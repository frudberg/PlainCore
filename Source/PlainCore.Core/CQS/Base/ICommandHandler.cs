using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainCore.Core.CQS.Base
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        CommandResult Execute(TCommand command);
        Task<CommandResult> ExecuteAsync(TCommand command);
    }
}
