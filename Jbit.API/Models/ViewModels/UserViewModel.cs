using System;

namespace Jbit.API.Models.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {

        }

        public UserViewModel(Guid id, string firstName, string lastName,
            string email, DateTime? registrationTimestamp, Guid? personId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            RegistrationTamistamp = registrationTimestamp;
            PersonId = personId;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? RegistrationTamistamp { get; set; }
        public Guid? PersonId { get; set; }
    }
}
