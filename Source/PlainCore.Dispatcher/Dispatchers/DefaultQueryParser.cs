using PlainCore.Core.CQS.Base;
using PlainCore.Core.Externals.Dispatcher;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Dispatcher.Dispatchers
{
    public class DefaultQueryParser : IQueryParser
    {
        private IContainer ioCContainer;

        public DefaultQueryParser(IContainer ioCContainer)
        {
            this.ioCContainer = ioCContainer;
        }

        public TResult Process<TResult>(IQuery<TResult> query)
        {
            try
            {
                var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
                dynamic handler = ioCContainer.GetInstance(handlerType);

                if (handler == null)
                    throw new QueryHandlerNotFoundException(typeof(IQuery<TResult>));

                return handler.Handle((dynamic)query);
            }
            catch (StructureMapConfigurationException)
            {
                throw new QueryHandlerNotFoundException(typeof(IQuery<TResult>));
            }
        }
    }
}
