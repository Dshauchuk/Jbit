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

        private List<TeamPerson> _teamPersons;
        public IReadOnlyCollection<Person> Persons => _teamPersons?.Select(tp => tp.Person).ToList().AsReadOnly();
        public IReadOnlyCollection<TeamPerson> TeamPersons => _teamPersons?.ToList().AsReadOnly();

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
            if(_teamPersons is null)
            {
                _teamPersons = new List<TeamPerson>();
            }

            _teamPersons.Add(new TeamPerson(this, person));
        }

        public void RemoveMember(Person person)
        {
            if(_teamPersons is null)
            {
                throw new InvalidOperationException("Cannot perform deletion - the team has no persons");
            }

            _teamPersons.RemoveAll(tp => tp.PersonId == person.Id);
        }

        public double GetTeamRating(ITaskRatingCalculator ratingCalculator = null)
        {
            return _teamPersons.Select(tp => tp.Person).Sum(p => p.GetPersonRating(ratingCalculator));
        }
    }
}
