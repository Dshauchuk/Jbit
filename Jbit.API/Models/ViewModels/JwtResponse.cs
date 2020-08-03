using System;

namespace Jbit.API.Models.ViewModels
{
    public class JwtResponse
    {
        public JwtResponse()
        {

        }

        public JwtResponse(Guid userId, string accessToken,
            string refreshToken, int expiresIn)
        {
            UserId = userId;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            ExpiresIn = expiresIn;
        }

        public Guid UserId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
