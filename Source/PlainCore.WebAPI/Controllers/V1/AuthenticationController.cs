using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using AspNet.Security.OpenIdConnect.Primitives;
using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Server;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using PlainCore.Core.Externals.Identities;
using Microsoft.AspNetCore.Http;
using PlainCore.Core.DomainModels.Identities;
using StructureMap;
using Microsoft.Extensions.DependencyInjection;

namespace PlainCore.WebAPI.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly IIdentityUserManager userManager;
        private readonly IApplicationSignInManager signInManager;

        public AuthenticationController(IContainer container,
                                        IHttpContextAccessor contextAccessor,
                                        IIdentityUserManager userManager,
                                        IApplicationSignInManager signInManager) : base(container)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAuthenticationTicketByPassword()
        {
            var request = HttpContext.GetOpenIdConnectRequest();
            if (request.IsPasswordGrantType())
            {
                var applicationUser = userManager.FindByNameAsync(request.Username).Result;
                if (applicationUser != null)
                {
                    if (!userManager.CheckPasswordAsync(applicationUser, request.Password).Result)
                    {
                        if (userManager.SupportsUserLockout)
                            userManager.AccessFailedAsync(applicationUser).Wait();

                        return Unauthorized();
                    }
                    else
                    {
                        AuthenticationTicket ticket = CreateTicketAsync(applicationUser, request.GetResources(), request.GetScopes()).Result;
                        var result =  SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
                        return result;
                    }
                }
                else
                    return Unauthorized();
            }
            else if (request.IsRefreshTokenGrantType())
            {
                AuthenticateResult info = await HttpContext.AuthenticateAsync(OpenIdConnectServerDefaults.AuthenticationScheme);
                ApplicationUser applicationUser = await userManager.GetUserAsync(info.Principal);

                if (!await signInManager.CanSignInAsync(applicationUser))
                    return Unauthorized();

                AuthenticationTicket ticket = await CreateTicketAsync(applicationUser, request.GetResources(), request.GetScopes(), info.Properties);
                return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
            }

            return Json(new OpenIdConnectResponse
            {
                Error = OpenIdConnectConstants.Errors.UnsupportedGrantType
            });
        }

        protected async Task<AuthenticationTicket> CreateTicketAsync(ApplicationUser applicationUser, IEnumerable<string> resources, IEnumerable<string> scopes, Microsoft.AspNetCore.Authentication.AuthenticationProperties properties = null)
        {
            ClaimsPrincipal principal = await signInManager.CreateUserPrincipalAsync(applicationUser);

            (principal.Identity as ClaimsIdentity).AddClaim("given_name", applicationUser.UserName,
                OpenIdConnectConstants.Destinations.AccessToken,
                OpenIdConnectConstants.Destinations.IdentityToken);

            if (properties == null) { properties = new Microsoft.AspNetCore.Authentication.AuthenticationProperties(); }
            AuthenticationTicket ticket = new AuthenticationTicket(principal, properties, OpenIdConnectServerDefaults.AuthenticationScheme);

            ticket.SetResources(resources);
            ticket.SetScopes(scopes);
            return ticket;
        }

        [HttpPost("Revoke")]
        [AllowAnonymous]
        public IActionResult RevokeRefreshToken()
        {
            var request = HttpContext.GetOpenIdConnectRequest();
            return Ok();
        }
    }
}
