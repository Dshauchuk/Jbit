using System;

namespace Jbit.Common.Exceptions
{
    public class JbitException : Exception
    {
        public const string DefaultCode = "error";
        public string Code { get; }

        public JbitException(string message)
            : base(message)
        {
            Code = DefaultCode;
        }

        public JbitException(string message, string code)
            : this(message)
        {
            Code = code;
        }
    }
}
