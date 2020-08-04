using Jbit.Common.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Jbit.Common.Auth.Extensions
{
    public static class UserAccountExtensions
    {
        public static ClaimsIdentity BuildClaims<T>(this T user, IList<string> roles)
            where T : User
        {
            var roleClaims = roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)).ToList();

            var defaultClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, $"{user.FirstName} {user.LastName}"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.TimeOfDay.Ticks.ToString(),
                    ClaimValueTypes.Integer64)
            };

            var claims = defaultClaims.Concat(roleClaims);

            return new ClaimsIdentity(claims, "token");
        }
    }
}
