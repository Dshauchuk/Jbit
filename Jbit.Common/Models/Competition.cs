using Jbit.Common.Models.Abstract;
using Jbit.Common.Validation;
using Jbit.Common.Validation.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jbit.Common.Models
{
    public class Competition : IIdentifiable, IValidatable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<JbitTask> TaskLinks { get; set; }

        public Competition()
        {

        }

        public Competition(Guid id, string name, string description, ICollection<JbitTask> taskLinks)
        {
            Id = id;
            Name = name;
            Description = description;
            TaskLinks = taskLinks;
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
