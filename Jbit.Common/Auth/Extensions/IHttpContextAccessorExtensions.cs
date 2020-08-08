using Jbit.Common.Exceptions;
using Jbit.Common.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace Jbit.Common.Auth.Extensions
{
    public static class IHttpContextAccessorExtensions
    {
        public static UserContext GetUserContext(this IHttpContextAccessor httpContextAccessor)
        {
            var idClaim = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userid");
            var emailClaim = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            return new UserContext(idClaim != null ? Guid.Parse(idClaim.Value) : throw new UnauthorizedException(), emailClaim?.Value ?? string.Empty);
        }
    }
}
