using System;

namespace Jbit.Common.Models
{
    public class UserContext
    {
        public UserContext(Guid id, string email)
        {
            UserId = id;
            Email = email;
        }

        public Guid UserId { get; }
        public string Email { get; }
    }
}
