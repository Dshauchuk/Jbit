using Jbit.Common.Validation;
using Jbit.Common.Validation.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jbit.API.Models.ViewModels
{
    public class RegistrationViewModel : IValidatable
    {
        public string Email { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string DeviceId { get; set; }
        public string Device { get; set; }

        public Result Validate()
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Email))
                errors.Add(new ValidationResult("Email is not specified"));

            if (string.IsNullOrWhiteSpace(Password))
                errors.Add(new ValidationResult("Password is not specified"));
            else if (Password.Length < 6)
                errors.Add(new ValidationResult("Password must have at least 6 characters"));

            return new Result(errors);
        }
    }
}
