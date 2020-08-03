using System.Collections.Generic;

namespace Jbit.Common.Services
{
    public class RatingCalculator : IRatingCalculator
    {
        public decimal Evaluate(string expression, Dictionary<string, decimal> argument = null)
        {
            var engine = new ExpressionEvaluator();

            return engine.Evaluate(expression, argument ?? new Dictionary<string, decimal>());
        }
    }
}
