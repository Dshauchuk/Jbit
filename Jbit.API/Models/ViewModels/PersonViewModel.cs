using System;
using System.Collections.Generic;

namespace Jbit.API.Models.ViewModels
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Avatar { get; set; }
        public Guid OwnerId { get; set; }
        public Guid? UserId { get; set; }
        public decimal Points { get; set; }
        public virtual ICollection<TaskViewModel> Tasks { get; set; }
    }
}
