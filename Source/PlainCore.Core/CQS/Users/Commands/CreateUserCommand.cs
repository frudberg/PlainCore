using PlainCore.Core.CQS.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Core.CQS.Users
{
    public class CreateUserCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public bool EmailConfirmed { get; set; }
        public Guid TenantID { get; set; }
    }
}
