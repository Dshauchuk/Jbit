using Jbit.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jbit.API.Data.Mapping
{
    public class CompetitionPersonMapping : IEntityTypeConfiguration<CompetitionPerson>
    {
        public void Configure(EntityTypeBuilder<CompetitionPerson> builder)
        {
            builder.ToTable("competition_persons");

            builder.HasKey(e => new { e.CompetitionId, e.PersonId });

            builder.Property(e => e.CompetitionId).IsRequired().HasColumnName("competition_id");
            builder.Property(e => e.PersonId).IsRequired().HasColumnName("person_id");

            builder.HasOne(b => b.Person).WithMany(b => b.CompetitionLinks).HasForeignKey(t => t.PersonId);
            builder.HasOne(b => b.Competition).WithMany(b => b.PersonLinks).HasForeignKey(t => t.CompetitionId);
        }
    }
}
