using System;
using System.Collections.Generic;

namespace Jbit.API.Models.ViewModels
{
    public class ExtendedCompetitionViewModel
    {
        public ExtendedCompetitionViewModel()
        {

        }

        public ExtendedCompetitionViewModel(Guid id, string name,
            string description, IEnumerable<PersonViewModel> persons)
        {
            Id = id;
            Name = name;
            Description = description;
            Persons = persons;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ExpressionId { get; set; }
        public string ExpresionName { get; set; }
        public string ExpressionDescription { get; set; }
        public IEnumerable<PersonViewModel> Persons { get; set; }
    }
}
