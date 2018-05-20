using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StructureMap;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using PlainCore.Core.CQS.Tenants.Commands;
using PlainCore.Core.CQS.Tenants.Queries;
using PlainCore.Core.DomainModels.Tenants;
using static PlainCore.WebAPI.Authentication.RolePermissionFilter;
using PlainCore.WebAPI.Authentication;

namespace PlainCore.WebAPI.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class TenantController : BaseController
    {
        public TenantController(IContainer container) : base(container)
        {

        }

        [HttpPost("CreateTenant")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "API")]
        [AuthorizePermission(Permission.CanManageTenants)]
        public async Task<IActionResult> CreateTenant([FromBody]CreateNewTenantCommand command)
        {
            await this.WebApiCommandDispatcherAsync(command);
            return Ok();
        }

        [HttpGet("GetAllTenants")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "API")]
        [AuthorizePermission(Permission.CanReadTenants)]
        public async Task<IActionResult> GetAllTenants()
        {
            var result = WebApiQueryParser<GetAllTenantsQuery, IList<TenantDTO>>(new GetAllTenantsQuery());
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }
    }
}
