using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Core.CQS.Base
{
    public class QueryHandlerNotFoundException : Exception
    {
        public QueryHandlerNotFoundException(Type type)
            : base(string.Format("Query handler not found for query type: {0}", type))
        {
        }
    }
}
