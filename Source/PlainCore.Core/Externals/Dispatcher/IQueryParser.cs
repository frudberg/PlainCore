using PlainCore.Core.CQS.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Core.Externals.Dispatcher
{
    public interface IQueryParser
    {
        TResult Process<TResult>(IQuery<TResult> query);
    }
}
