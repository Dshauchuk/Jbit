using Jbit.Common.Models;
using System.Collections.Generic;

namespace Jbit.Common.Auth.Interfaces
{
    public interface IJwtTokenGenerator
    {
        JwtTokenResult Generate(User user, IList<string> roles);
    }
}
