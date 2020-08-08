using System;
using System.Collections.Generic;

namespace Jbit.API.Models.ViewModels
{
    public class ExtendedCompetitionViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ExpressionId { get; set; }
        public string ExpresionName { get; set; }
        public string ExpressionDescription { get; set; }
        public IEnumerable<PersonViewModel> Persons { get; set; }
    }
}
