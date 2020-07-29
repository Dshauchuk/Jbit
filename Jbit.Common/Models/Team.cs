using Jbit.Common.Models.Abstract;
using Jbit.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jbit.Common.Models
{
    public class Team : IIdentifiable
    {
        public Guid Id { get; }
        public string Title { get; set; }

        private List<TeamPerson> _personLinks;
        
        public IReadOnlyCollection<TeamPerson> PersonLinks => _personLinks?.ToList().AsReadOnly();

        public IReadOnlyCollection<Person> Members => _personLinks?.Select(l => l.Person).ToList().AsReadOnly();

        private Team()
        {

        }

        public Team(Guid id, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title));
            }

            Id = id;
            Title = title;
        }

        public void AddMember(Person person)
        {
            if (person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            if (_personLinks is null)
            {
                _personLinks = new List<TeamPerson>();
            }

            _personLinks.Add(new TeamPerson(this, person));
        }

        public void RemoveMember(Person person)
        {
            if (person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            if (_personLinks is null)
            {
                throw new InvalidOperationException("Cannot perform deletion - the team has no persons");
            }

            _personLinks.RemoveAll(tp => tp.PersonId == person.Id);
        }

        public double GetTeamRating(ITaskRatingCalculator ratingCalculator = null)
        {
            return _personLinks.Select(tp => tp.Person).Sum(p => p.GetPersonRating(ratingCalculator));
        }
    }
}
