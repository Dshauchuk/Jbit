using Jbit.Common.Validation;
using Jbit.Common.Validation.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jbit.API.Models.ViewModels
{
    public class CreateCompetitionModel : IValidatable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ExpressionId { get; set; }
        public string Expression { get; set; }
        public string ExpressionName { get; set; }
        public string ExpressionDescription { get; set; }

        public Result Validate()
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if(ExpressionId is null)
            {
                if(string.IsNullOrWhiteSpace(Expression))
                    errors.Add(new ValidationResult("Expression is not specified"));

                if (string.IsNullOrWhiteSpace(ExpressionName))
                    errors.Add(new ValidationResult("Expression name is not specified"));
            }

            if (string.IsNullOrWhiteSpace(Name))
                errors.Add(new ValidationResult("Competition name is not specified"));

            return new Result(errors);
        }
    }
}
