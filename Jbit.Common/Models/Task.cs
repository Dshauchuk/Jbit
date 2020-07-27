using Jbit.Common.Models.Abstract;
using Jbit.Common.Services;
using System;

namespace Jbit.Common.Models
{
    public class Task : IIdentifiable
    {
        public Guid Id { get; }
        public string Title { get;  }
        public Guid AssignedTo { get; }
        public double Hours { get; }
        public string Link { get; }
        public byte Corrections { get; }
        public byte FatalErrors { get; }

        // for EF Core
        private Task()
        {

        }

        public Task(Guid id, string title, double hours, Guid assignedTo,
            string link, byte corrections, byte fataErrors)
        {
            if(hours <= 0)
            {
                throw new ArgumentException("Task cannot be estimated at 0 hours");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            if(corrections < 0)
            {
                corrections = 0;
            }

            if(fataErrors < 0)
            {
                fataErrors = 0;
            }

            Hours = hours;
            Id = id;
            Title = title;
            AssignedTo = assignedTo;
            Link = link;
            Corrections = corrections;
            FatalErrors = fataErrors;
        }

        public double GetTaskRaiting(ITaskRatingCalculator ratingCalculator = null)
        {
            if(ratingCalculator != null)
            {
                return ratingCalculator.GetRating();
            }

            // default rating calculation
            return Hours * (1 / (Corrections * 0.3 + 1)) / FatalErrors + 1;
        }
    }
}
