using System;

namespace Jbit.API.Models.ViewModels
{
    public class SimplePersonViewModel
    {
        public SimplePersonViewModel()
        {

        }

        public SimplePersonViewModel(Guid id, string firstName, 
            string lastName, string email, byte[] avatar)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Avatar = avatar;
        }

        public Guid Id { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; set; }
        public byte[] Avatar { get; }
    }
}
