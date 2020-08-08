using Jbit.Common.Models.Abstract;
using Jbit.Common.Services;
using Jbit.Common.Validation;
using Jbit.Common.Validation.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Jbit.Common.Models
{
    public class Person : IIdentifiable, IValidatable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Avatar { get; set; }
        public Guid OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public decimal Points { get; set; }
        public virtual ICollection<JbitTask> TaskLinks { get; set; }
        public virtual ICollection<CompetitionPerson> CompetitionLinks { get; set; }

        public Person()
        {

        }

        public Person(Guid id, string firstName, string lastName, string email, decimal points,
            User owner, ICollection<JbitTask> tasks, ICollection<CompetitionPerson> competitionLinks)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            TaskLinks = tasks;
            Email = email;
            Points = points;

            Owner = owner;
            OwnerId = owner?.Id ?? Guid.Empty;

            CompetitionLinks = competitionLinks;
        }

        public decimal GetPersonRating(ITaskRatingCalculator ratingCalculator = null)
        {
            return TaskLinks?.Sum(t => t.GetTaskRaiting(ratingCalculator)) ?? 0;
        }

        public Result Validate()
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(FirstName))
                errors.Add(new ValidationResult("First name is not specified"));

            if (string.IsNullOrWhiteSpace(LastName))
                errors.Add(new ValidationResult("Last name is not specified"));

            if (string.IsNullOrWhiteSpace(Email))
                errors.Add(new ValidationResult("Email is not specified"));

            return new Result(errors);
        }
    }
}
