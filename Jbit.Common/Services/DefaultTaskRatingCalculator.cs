using System;

namespace Jbit.Common.Services
{
    class DefaultTaskRatingCalculator : ITaskRatingCalculator
    {


        public double GetRating()
        {
            return Hours * (1 / (Corrections * 0.3 + 1)) / FatalErrors + 1;
        }
    }
}
