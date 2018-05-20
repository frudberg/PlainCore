using PlainCore.Core.DomainModels.Base;
using PlainCore.Core.DomainModels.Identities;
using PlainCore.Core.DomainModels.Tenants;
using PlainCore.Core.DomainModels.UserRoles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PlainCore.Core.DomainModels.Users
{
    public class User : EntityBase<Guid>
    {
        public Tenant Tenant { get; private set; }
        public Guid? TenantId { get; private set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public UserRole UserRole { get; set; }

        [NotMapped]
        public AbstractUserRole UserRoleObject { get { return UserRoleFactory.GetRoleFromRoleUser(this.UserRole); } }
        
        private User()
        {

        }

        public User(ApplicationUser applicationUser)
        {
            this.ApplicationUserId = applicationUser.Id;
        }

        public User(ApplicationUser applicationUser, Tenant tenant) : this(applicationUser, tenant.Id)
        {

        }

        public User(ApplicationUser applicationUser, Guid tenantId)
        {
            this.TenantId = tenantId;
            this.ApplicationUserId = applicationUser.Id;
        }

        public UserDTO ToUserDTO()
        {
            return new UserDTO()
            {
                FirstName = this.ApplicationUser.FirstName,
                LastName = this.ApplicationUser.LastName,
                Username = this.ApplicationUser.UserName
            };
        }
    }
}
