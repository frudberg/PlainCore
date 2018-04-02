using PlainCore.Core.CQS.Base;
using PlainCore.Core.Externals.Dispatcher;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainCore.Dispatcher.Dispatchers
{
    public class DefaultCommandBus : ICommandBus
    {
        private IContainer ioCContainer;

        public DefaultCommandBus(IContainer ioCContainer)
        {
            this.ioCContainer = ioCContainer;
        }

        public CommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            ICommandHandler<TCommand> handler = null;
            try
            {
                handler = ioCContainer.GetInstance<ICommandHandler<TCommand>>();
                if (!((handler != null) && handler is ICommandHandler<TCommand>))
                    throw new CommandHandlerNotFoundException(typeof(TCommand));

                return handler.Execute(command);
            }
            catch (StructureMapConfigurationException)
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }
        }

        public async Task<CommandResult> SubmitAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            ICommandHandler<TCommand> handler = null;
            try
            {
                handler = ioCContainer.GetInstance<ICommandHandler<TCommand>>();
                if (!((handler != null) && handler is ICommandHandler<TCommand>))
                    throw new CommandHandlerNotFoundException(typeof(TCommand));

                return await handler.ExecuteAsync(command);
            }
            catch (StructureMapConfigurationException)
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }
        }

        public ValidationResult Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            IValidationHandler<TCommand> handler = null;
            try
            {
                handler = ioCContainer.GetInstance<IValidationHandler<TCommand>>();
                if (!((handler != null) && handler is IValidationHandler<TCommand>))
                    throw new ValidationHandlerNotFoundException(typeof(TCommand));

                return handler.Validate(command);
            }
            catch (StructureMapConfigurationException)
            {
                throw new ValidationHandlerNotFoundException(typeof(TCommand));
            }
        }

        public async Task<ValidationResult> ValidateAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            IValidationHandler<TCommand> handler = null;
            try
            {
                handler = ioCContainer.GetInstance<IValidationHandler<TCommand>>();
                if (!((handler != null) && handler is IValidationHandler<TCommand>))
                    throw new ValidationHandlerNotFoundException(typeof(TCommand));

                return handler.Validate(command);
            }
            catch (StructureMapConfigurationException)
            {
                throw new ValidationHandlerNotFoundException(typeof(TCommand));
            }
        }
    }
}
