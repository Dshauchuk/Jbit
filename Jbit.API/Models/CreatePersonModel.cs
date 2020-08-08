using Jbit.Common.Validation;
using Jbit.Common.Validation.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jbit.API.Models
{
    public class CreatePersonModel : IValidatable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Avatar { get; set; }
        public Guid OwnerId { get; set; }
        public Guid? UserId { get; set; }
        public Guid[] Competitions { get; set; }

        public Result Validate()
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(FirstName))
                errors.Add(new ValidationResult("First name is not specified"));

            if (string.IsNullOrWhiteSpace(LastName))
                errors.Add(new ValidationResult("First name is not specified"));

            return new Result(errors);
        }
    }
}
