using System;

namespace Jbit.API.Models
{
    public class UserContext
    {
        public UserContext(Guid id, string email)
        {
            Id = id;
            Email = email;
        }

        public Guid Id { get; }
        public string Email { get; }
    }
}
