using Jbit.Common.Models.Abstract;
using System;
using System.Collections.Generic;

namespace Jbit.Common.Models
{
    public class JbitExpression : IIdentifiable
    {
        public JbitExpression()
        {

        }

        public JbitExpression(string name, string expressionString, string description)
        {
            Name = name;
            ExpressionString = expressionString;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ExpressionString { get; set; }
        public string Description { get; set; }
        public ICollection<Competition> Competitions { get; set; }
    }
}
