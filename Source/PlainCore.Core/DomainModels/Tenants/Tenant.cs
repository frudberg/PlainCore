using PlainCore.Core.DomainModels.Base;
using PlainCore.Core.DomainModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlainCore.Core.DomainModels.Tenants
{
    public class Tenant : EntityBase<Guid>
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();

        public TenantDTO ToTenantDTO()
        {
            return new TenantDTO()
            {
                Name = this.Name,
                UsersCount = this.Users.Count
            };
        }
    }
}
