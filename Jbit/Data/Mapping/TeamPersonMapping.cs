using Jbit.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jbit.Web.Data.Mapping
{
    public class TeamPersonMapping : IEntityTypeConfiguration<TeamPerson>
    {
        public void Configure(EntityTypeBuilder<TeamPerson> builder)
        {
            builder.ToTable("team_members");

            builder.HasKey(e => new { e.TeamId, e.PersonId });

            builder.Property(e => e.TeamId).IsRequired().HasColumnName("team_id");
            builder.Property(e => e.PersonId).IsRequired().HasColumnName("person_id");

            builder.HasOne(e => e.Person).WithMany().HasForeignKey(e => e.PersonId);
            builder.HasOne(e => e.Team).WithMany().HasForeignKey(e => e.TeamId);
        }
    }
}
