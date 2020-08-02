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
            Competition = competition;
            CompetitionId = competition?.Id ?? Guid.Empty;
            Person = person;
            PersonId = person?.Id ?? Guid.Empty;
        }
    }
}
