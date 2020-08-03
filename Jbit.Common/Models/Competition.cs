using Jbit.Common.Models.Abstract;
using Jbit.Common.Validation;
using Jbit.Common.Validation.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jbit.Common.Models
{
    public class Competition : IIdentifiable, IValidatable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public Guid? ExpressionId { get; set; }
        public virtual JbitExpression Expression { get; set; }
        public ICollection<JbitTask> TaskLinks { get; set; }
        public ICollection<CompetitionPerson> PersonLinks { get; set; }

        public Competition()
        {

        }

        public Competition(Guid id, string name, string description, User owner, JbitExpression expression,
            ICollection<JbitTask> taskLinks, ICollection<CompetitionPerson> personLinks)
        {
            Id = id;
            Name = name;
            Description = description;
            TaskLinks = taskLinks;
            PersonLinks = personLinks;
            Owner = owner;
            OwnerId = owner?.Id ?? Guid.Empty;
            Expression = expression;
            JbitExpressionId = expression?.Id;
        }

        public Result Validate()
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Name))
                errors.Add(new ValidationResult("Name is not specified"));

            return new Result(errors);
        }
    }
}
