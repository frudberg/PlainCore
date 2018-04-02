using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlainCore.Core.Externals.Identities
{
    public interface IIdentityPasswordValidator
    {
        Task<IdentityResult> ValidateAsync(string password);
    }
}
