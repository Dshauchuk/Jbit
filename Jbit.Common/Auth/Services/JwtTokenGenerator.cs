using Jbit.Common.Auth.Extensions;
using Jbit.Common.Auth.Interfaces;
using Jbit.Common.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace Jbit.Common.Auth.Services
{
    public sealed class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _tokenOptions;
        public JwtTokenGenerator(JwtOptions tokenOptions)
        {
            _tokenOptions = tokenOptions ??
                            throw new ArgumentNullException(
                                $"An instance of valid {nameof(JwtOptions)} must be passed in order to generate a JWT!");
        }

        public JwtTokenResult Generate(User user, IList<string> roles)
        {
            var expiration = TimeSpan.FromMinutes(_tokenOptions.TokenExpiryInMinutes);
            var claimsIdentity = user.BuildClaims(roles);

            var jwt = new JwtSecurityToken(
                _tokenOptions.Issuer,
                _tokenOptions.Audience,
                claimsIdentity.Claims,
                DateTime.UtcNow,
                DateTime.UtcNow.Add(expiration),
                new SigningCredentials(
                    _tokenOptions.SigningKey,
                    SecurityAlgorithms.HmacSha256));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtTokenResult
            {
                AccessToken = accessToken,
                Expires = expiration
            };
        }
    }
}
