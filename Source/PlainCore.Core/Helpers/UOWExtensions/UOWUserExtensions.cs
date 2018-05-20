using Microsoft.EntityFrameworkCore;
using PlainCore.Core.DomainModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace PlainCore.Core.Helpers.UOWExtensions
{
    public static class UOWUserExtensions
    {
        public static IList<UserDTO> GetUsersAsDTO(this DbSet<User> dbSet)
        {
            return dbSet.Include(x => x.ApplicationUser).Select(x => x.ToUserDTO()).ToList();
        }

        public static async Task<User> GetUserByAppIdIncludeAppUser(this DbSet<User> dbSet, string appUserId)
        {
            return await dbSet.Include(x => x.ApplicationUser).Where(x => x.ApplicationUserId == appUserId).SingleOrDefaultAsync();
        }
    }
}
