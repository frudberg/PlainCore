using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Primitives;
using AspNet.Security.OpenIdConnect.Server;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using PlainCore.Core.DomainModels.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace PlainCore.WebAPI.Helpers.Authorization
{
    public sealed class AuthorizationProvider : OpenIdConnectServerProvider
    {
        private UserManager<ApplicationUser> userManager;
        public AuthorizationProvider(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public override async Task ValidateTokenRequest(ValidateTokenRequestContext context)
        {
            // Reject token requests that don't use grant_type=password or grant_type=refresh_token.
            if (!context.Request.IsPasswordGrantType() && !context.Request.IsRefreshTokenGrantType())
            {
                context.Reject(
                    error: OpenIdConnectConstants.Errors.UnsupportedGrantType,
                    description: "Only grant_type=password and refresh_token " +
                                 "requests are accepted by this server.");
                return;
            }

            //context.Validate();

            var applicationUser = await userManager.FindByNameAsync(context.Request.Username);

            if (applicationUser == null)
            {
                context.Reject(
                    error: OpenIdConnectConstants.Errors.InvalidGrant,
                    description: "Invalid user credentials.");

                return;
            }

            // Ensure the password is valid.
            if (!await userManager.CheckPasswordAsync(applicationUser, context.Request.Password))
            {
                if (userManager.SupportsUserLockout)
                {
                    await userManager.AccessFailedAsync(applicationUser);
                }

                context.Reject(
                   error: OpenIdConnectConstants.Errors.InvalidGrant,
                   description: "Invalid user credentials.");

                return;
            }

            var identity = new ClaimsIdentity(
                OpenIdConnectServerDefaults.AuthenticationScheme,
                OpenIdConnectConstants.Claims.Name,
                OpenIdConnectConstants.Claims.Role);

            identity.AddClaim(
                new Claim(OpenIdConnectConstants.Claims.Subject, applicationUser.UserName)
                    .SetDestinations(OpenIdConnectConstants.Destinations.AccessToken,
                                     OpenIdConnectConstants.Destinations.IdentityToken));

            identity.AddClaim(
                new Claim(OpenIdConnectConstants.Claims.Name, applicationUser.UserName)
                    .SetDestinations(OpenIdConnectConstants.Destinations.AccessToken,
                                     OpenIdConnectConstants.Destinations.IdentityToken));
        }

        public override async Task ValidateAuthorizationRequest(ValidateAuthorizationRequestContext context)
        {
            if (context.Request.IsPasswordGrantType())
            {

            }
        }
    }
}
