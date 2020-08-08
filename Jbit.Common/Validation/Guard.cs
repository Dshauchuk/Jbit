using Jbit.Common.Exceptions;
using Jbit.Common.Models;
using Jbit.Common.Validation.Abstract;
using System;

namespace Jbit.Common.Validation
{
    public static class Guard
    {
        public static void IsNotNull(object arg, string argName = "parameter")
        {
            if (arg is null)
                throw new ArgumentNullException(argName);
        }

        public static void UserIsNotNull(UserContext userContext)
        {
            if (userContext is null)
                throw new UnauthorizedException();
        }

        public static void ModelIsValid<T>(T model) where T: IValidatable
        {
            var validationResult = model.Validate();

            if (!validationResult.Success)
                throw new JbitException(string.Join(";", validationResult.ErrorMessages));
        }
    }
}
