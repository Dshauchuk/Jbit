using System;

namespace Jbit.Common.Models
{
    public class TeamPerson
    {
        public Guid TeamId { get; }
        public virtual Team Team { get; set; }        
        public Guid PersonId { get; }
        public virtual Person Person { get; set; }

        private TeamPerson()
        {

        }

        internal TeamPerson(Team team, Person person)
        {
            if(team is null)
            {
                throw new ArgumentNullException(nameof(team));
            }

            if (person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            TeamId = team.Id;
            Team = team;
            PersonId = person.Id;
            Person = person;
        }
    }
}
