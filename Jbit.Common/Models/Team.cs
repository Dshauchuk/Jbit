using Jbit.Common.Models.Abstract;
using Jbit.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jbit.Common.Models
{
    public class Team : IIdentifiable
    {
        private int DefaultTeamCapacity = 100;

        public Guid Id { get; }
        public string Title { get; set; }

        private List<Person> _persons;
        public IReadOnlyCollection<Person> Persons => _persons?.ToList();

        private Team()
        {

        }

        public Team(Guid id, string title, ICollection<Person> persons)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            Id = id;
            Title = title;

            if(persons != null)
            {
                _persons = new List<Person>(persons);
            }
        }

        public void AddMember(Guid id, string firstName, string lastName,
            Guid teamId, ICollection<Task> tasks, byte[] avatar = null)
        {
            if(_persons is null)
            {
                _persons = new List<Person>(DefaultTeamCapacity);
            }

            _persons.Add(new Person(id, firstName, lastName,
                teamId, tasks, avatar));
        }

        public void RemoveMember(Person person)
        {
            if(_persons is null)
            {
                throw new InvalidOperationException("Cannot perform deletion - the team has no persons");
            }

            _persons.Remove(person);
        }

        public double GetTeamRating(ITaskRatingCalculator ratingCalculator = null)
        {
            return _persons.Sum(p => p.GetPersonRating(ratingCalculator));
        }
    }
}
