using Jbit.Common.Models.Abstract;
using System;

namespace Jbit.Common.Models
{
    public class User : IIdentifiable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? RegistrationTamistamp { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public User()
        {

        }

        public User(Guid id, string email, string firstName, string lastName,
            Person person)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Person = person;
            PersonId = person?.Id ?? Guid.Empty;
        }
    }
}