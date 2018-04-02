using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainCore.Core.CQS.Base
{
    public abstract class AbstractCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        public virtual CommandResult Execute(TCommand command)
        {
            return Task.Run(() => ExecuteAsync(command)).Result;
        }

        public virtual async Task<CommandResult> ExecuteAsync(TCommand command)
        {
            return await Task.FromResult(new CommandResult());
        }
    }
}
