using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PlainCore.Core.DomainModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Core.DomainModels.Identities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSuperAdministrator { get; set; }
        public IEnumerable<User> Users { get; set; } = new List<User>();
        
    }
}
 