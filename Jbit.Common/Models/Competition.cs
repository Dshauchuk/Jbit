using Jbit.Common.Models.Abstract;
using Jbit.Common.Validation;
using Jbit.Common.Validation.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jbit.Common.Models
{
    // TODO: Think about expressions!


    public class Competition : IIdentifiable, IValidatable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public User Owner { get; set; }
        public ICollection<JbitTask> TaskLinks { get; set; }
        public ICollection<CompetitionPerson> PersonLinks { get; set; }

        public Competition()
        {

        }

        public Competition(Guid id, string name, string description, User owner,
            ICollection<JbitTask> taskLinks, ICollection<CompetitionPerson> personLinks)
        {
            Id = id;
            Name = name;
            Description = description;
            TaskLinks = taskLinks;
            PersonLinks = personLinks;
            Owner = owner;
            OwnerId = owner?.Id ?? Guid.Empty;
        }

        public Result Validate()
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Name))
                errors.Add(new ValidationResult("Name is not specified"));

            return new Result(errors);
        }
    }
}
