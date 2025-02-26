using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;

namespace Movies.Api.Auth
{
    public class AdminAuthRequirement : IAuthorizationHandler, IAuthorizationRequirement
    {
        private readonly string _apiKey;

        public AdminAuthRequirement(string apiKey)
        {
            _apiKey = apiKey;
        }

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            if (context.User.HasClaim(AuthConstants.AdminClaimName, "true"))
            {
                context.Succeed(this);
                return Task.CompletedTask;
            }

            var httpContext = context.Resource as HttpContext;
            if (httpContext is null)
            {
                return Task.CompletedTask;  
            }
            if (!httpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName, out StringValues extractedApiKey))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            if(_apiKey != extractedApiKey)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var identity = (ClaimsIdentity)httpContext.User.Identity!;
            identity.AddClaim(new Claim("userid", Guid.Parse("9c307c10-cd84-4494-8875-79c806c5cc69").ToString()));
            context.Succeed(this);
            return Task.CompletedTask;
        }
    }
}
