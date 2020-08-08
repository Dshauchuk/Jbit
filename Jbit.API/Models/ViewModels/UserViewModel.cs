using System;

namespace Jbit.API.Models.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? RegistrationTimestamp { get; set; }
        public Guid? PersonId { get; set; }
    }
}
