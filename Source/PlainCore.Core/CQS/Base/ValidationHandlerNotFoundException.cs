using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Core.CQS.Base
{
    public class ValidationHandlerNotFoundException : Exception
    {
        public ValidationHandlerNotFoundException(Type type)
           : base(string.Format("Validation handler not found for command type: {0}", type))
        {
        }
    }
}
