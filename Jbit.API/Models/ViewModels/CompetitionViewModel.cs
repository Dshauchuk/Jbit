﻿using System;
using System.Collections.Generic;

namespace Jbit.API.Models.ViewModels
{
    public class CompetitionViewModel
    {
        public CompetitionViewModel()
        {

        }

        public CompetitionViewModel(Guid id, string name, 
            string description, IEnumerable<SimplePersonViewModel> persons)
        {
            Id = id;
            Name = name;
            Description = description;
            Persons = persons;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<SimplePersonViewModel> Persons { get; set; }
    }
}