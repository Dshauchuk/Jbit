using Jbit.API.Models.ViewModels;
using Jbit.Common.Validation;
using Jbit.Common.Validation.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jbit.API.Models
{
    public class CreateTaskModel : IValidatable
    {
        public string Title { get; set; }
        public Guid AssignedTo { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public Guid CompetitionId { get; set; }
        public ICollection<TaskValueModel> Values { get; set; }

        public Result Validate()
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Title))
                errors.Add(new ValidationResult("Task title is not specified"));

            return new Result(errors);
        }
    }
}
