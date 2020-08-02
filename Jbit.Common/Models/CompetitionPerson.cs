using System;

namespace Jbit.Common.Models
{
    public class CompetitionPerson
    {
        public Guid CompetitionId { get; set; }
        public Competition Competition { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public CompetitionPerson()
        {

        }

        public CompetitionPerson(Competition competition, Person person)
        {
            if (competition is null)
            {
                throw new ArgumentNullException(nameof(competition));
            }

            if (person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            CompetitionId = competition.Id;
            Competition = competition;
            PersonId = person.Id;
            Person = person;
        }
    }
}
