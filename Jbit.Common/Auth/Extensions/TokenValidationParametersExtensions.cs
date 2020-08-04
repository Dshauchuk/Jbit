using Microsoft.IdentityModel.Tokens;
using System;

namespace Jbit.Common.Auth.Extensions
{
    public static class TokenValidationParametersExtensions
    {
        internal static TokenValidationParameters ToTokenValidationParams(
            this JwtOptions tokenOptions) =>
            new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,
                ValidateAudience = false,
                ValidAudience = tokenOptions.Audience,
                ValidateIssuer = false,
                ValidIssuer = tokenOptions.Issuer,
                IssuerSigningKey = tokenOptions.SigningKey,
                ValidateIssuerSigningKey = true,
                RequireExpirationTime = true,
                ValidateLifetime = true
            };
    }
}
