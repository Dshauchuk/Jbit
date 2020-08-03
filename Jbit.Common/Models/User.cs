using Jbit.Common.Models.Abstract;
using System;
using System.Collections.Generic;

namespace Jbit.Common.Models
{
    public class User : IIdentifiable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? RegistrationTimestamp { get; set; }
        public virtual Person UserPerson { get; set; }
        public ICollection<Person> CreatedPersons { get; set; }
        public ICollection<Identity> UserLogins { get; set; }
        public ICollection<Competition> Competitions { get; set; }

        public User()
        {

        }

        public User(Guid id, string email, string firstName, string lastName)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}