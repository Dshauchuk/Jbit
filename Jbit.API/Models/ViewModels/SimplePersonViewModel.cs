using System;

namespace Jbit.API.Models.ViewModels
{
    public class SimplePersonViewModel
    {
        public SimplePersonViewModel()
        {

        }

        public SimplePersonViewModel(Guid id, string firstName, 
            string lastName, string email, decimal points, byte[] avatar)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Avatar = avatar;
            Points = points;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Avatar { get; set; }
        public decimal Points { get; set; }
    }
}
