using System;

namespace Jbit.Common.Auth
{
    public sealed class JwtTokenResult
    {
        public string AccessToken { get; internal set; }

        public TimeSpan Expires { get; set; }
    }
}
