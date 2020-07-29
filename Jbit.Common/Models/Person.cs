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

        private List<PersonTask> _tasks;
        public IReadOnlyCollection<PersonTask> Tasks => _tasks?.ToList();

        private Person()
        {

        }

        public Person(Guid id, string firstName, string lastName, byte[] avatar = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Avatar = avatar;
        }

        public void AddTask(Guid id, string title, double hours, 
            string link, byte corrections, byte fataErrors)
        {
            if(_tasks is null)
            {
                _tasks = new List<PersonTask>();
            }

            _tasks.Add(
                new PersonTask(id, title, hours, Id, link, corrections, fataErrors));
        }

        public void RemoveTask(PersonTask task)
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
