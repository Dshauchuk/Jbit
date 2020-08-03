using System.Collections.Generic;

namespace Jbit.Common.Services
{
    public interface IRatingCalculator
    {
        decimal Evaluate(string expression, Dictionary<string, decimal> arguments = null);
    }
}
