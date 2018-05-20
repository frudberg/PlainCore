using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlainCore.Core.CQS.Users;
using PlainCore.Core.CQS.Users.Queries;
using PlainCore.Core.DomainModels.Users;
using PlainCore.WebAPI.Authentication;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static PlainCore.WebAPI.Authentication.RolePermissionFilter;

namespace PlainCore.WebAPI.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class UserController : BaseController
    {
        public UserController(IContainer container) : base(container)
        {

        }

        [HttpPost("CreateUser")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "API")]
        [AuthorizePermission(Permission.CanManageUsers)]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommand command)
        {
            await this.WebApiCommandDispatcherAsync(command);
            return Ok();
        }

        [HttpGet("GetAllUsers")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "API")]
        [AuthorizePermission(Permission.CanReadUsers)]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = this.WebApiQueryParser<GetAllUsersQuery, IList<UserDTO>>(new GetAllUsersQuery());
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }
    }
}
