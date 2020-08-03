using System;
using System.Collections.Generic;

namespace Jbit.API.Models.ViewModels
{
    public class TaskViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid AssignedTo { get; set; }
        public string AssignedPersonFirstName { get; set; }
        public string AssignedPersonLastName { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public Guid CompetitionId { get; set; }
        public string CompetitionName { get; set; }
        public ICollection<TaskValueViewModel> Values { get; set; }
    }
}
