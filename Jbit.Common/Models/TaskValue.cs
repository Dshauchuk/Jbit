using Jbit.Common.Models.Abstract;
using System;

namespace Jbit.Common.Models
{
    public class TaskValue : IIdentifiable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public decimal Value { get; set; }

        public Guid TaskId { get; set; }
        public JbitTask Task { get; set; }
        
        public TaskValue()
        {

        }

        public TaskValue(string name, decimal value, JbitTask task)
        {
            Name = name;
            Value = value;
            TaskId = task?.Id ?? Guid.Empty;
            Task = task;
        }
    }
}
