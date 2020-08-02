using System.ComponentModel.DataAnnotations;
using Jbit.Common.Validation;

namespace Jbit.Common.Validation.Abstract
{
    public interface IValidatable
    {
        Result Validate();
    }
}