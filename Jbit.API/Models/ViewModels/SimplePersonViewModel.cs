using System;

namespace Jbit.API.Models.ViewModels
{
    public class SimplePersonViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Avatar { get; set; }
        public decimal Points { get; set; }
    }
}
