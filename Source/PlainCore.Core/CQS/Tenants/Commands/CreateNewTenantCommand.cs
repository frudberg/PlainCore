using PlainCore.Core.CQS.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Core.CQS.Tenants.Commands
{
    public class CreateNewTenantCommand : ICommand
    {
        public string Name { get; set; }
    }
}
