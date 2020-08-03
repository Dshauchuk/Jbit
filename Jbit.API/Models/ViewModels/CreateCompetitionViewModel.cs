﻿using System;

namespace Jbit.API.Models.ViewModels
{
    public class CreateCompetitionViewModel
    {
        public CreateCompetitionViewModel()
        {

        }

        public CreateCompetitionViewModel(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ExpressionId { get; set; }
        public string ExpresionName { get; set; }
        public string ExpressionDescription { get; set; }
    }
}
