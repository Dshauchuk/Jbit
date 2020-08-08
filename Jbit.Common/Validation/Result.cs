using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Jbit.Common.Validation
{
    public class Result
    {
        public IEnumerable<ValidationResult> Errors { get; }
        public IEnumerable<string> ErrorMessages => Errors?.Select(e => e.ErrorMessage);
        public bool Success => Errors is null || !Errors.Any();
        public static Result OK => new Result(null);

        public Result(IEnumerable<ValidationResult> errors)
        {
            Errors = errors;
        }
    }
}
