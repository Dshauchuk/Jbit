using Jbit.Common.Exceptions;
using Jbit.Common.Models.Abstract;
using Jbit.Common.Services;
using Jbit.Common.Validation;
using Jbit.Common.Validation.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jbit.Common.Models
{
    public class JbitTask : IIdentifiable, IValidatable
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid AssignedTo { get; set; }
        public Person Person { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public Guid CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public ICollection<TaskValue> Values { get; set; }

        public JbitTask()
        {

        }

        public JbitTask(Guid id, string title, string description, Person assignedTo,
            string link, Competition competition, ICollection<TaskValue> values)
        {
            Id = id;
            Title = title;
            Description = description;
            AssignedTo = assignedTo?.Id ?? Guid.Empty;
            Person = assignedTo;
            Link = link;
            Values = values;
            Competition = competition;
            CompetitionId = competition?.Id ?? Guid.Empty;
        }

        public decimal GetTaskRaiting(ITaskRatingCalculator ratingCalculator)
        {
            if(ratingCalculator is null) 
                throw new JbitException("ratingCalculator is not specified", "rating_calculation_failed");

            return ratingCalculator.GetRating();
        }

        public Result Validate()
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Title))
                errors.Add(new ValidationResult("Title is not specified"));

            return new Result(errors);
        }
    }
}
