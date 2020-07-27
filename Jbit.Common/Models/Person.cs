using Jbit.Common.Models.Abstract;
using Jbit.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jbit.Common.Models
{
    public class Person : IIdentifiable
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public byte[] Avatar { get; }
        public Guid TeamId { get; }

        private List<Task> _tasks;
        public IReadOnlyCollection<Task> Tasks => _tasks?.ToList();

        private Person()
        {

        }

        public Person(Guid id, string firstName, string lastName, 
            Guid teamId, ICollection<Task> tasks, byte[] avatar = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            TeamId = teamId;
            Avatar = avatar;

            if(tasks != null)
            {
                _tasks = new List<Task>(tasks);
            }
        }

        public void AddTask(Guid id, string title, double hours, Guid assignedTo, 
            string link, byte corrections, byte fataErrors)
        {
            if(_tasks is null)
            {
                _tasks = new List<Task>();
            }

            _tasks.Add(
                new Task(id, title, hours, assignedTo, link, corrections, fataErrors));
        }

        public void RemoveTask(Task task)
        {
            if(_tasks is null)
            {
                throw new InvalidOperationException("Person has no tasks");
            }

            _tasks.Remove(task);
        }

        public double GetPersonRating(ITaskRatingCalculator ratingCalculator = null)
        {
            return _tasks?.Sum(t => t.GetTaskRaiting(ratingCalculator)) ?? 0;
        }

    }
}
