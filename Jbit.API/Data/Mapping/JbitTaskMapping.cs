using Jbit.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jbit.API.Data.Mapping
{
    public class JbitTaskMapping : IEntityTypeConfiguration<JbitTask>
    {
        public void Configure(EntityTypeBuilder<JbitTask> builder)
        {
            builder.ToTable("tasks");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasColumnName("id");
            builder.Property(e => e.Title).IsRequired().HasColumnName("title");
            builder.Property(e => e.AssignedTo).IsRequired().HasColumnName("assigned_to");
            builder.Property(e => e.Link).HasColumnName("link");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.CompetitionId).IsRequired().HasColumnName("competition_id");

            builder.HasOne(b => b.Person).WithMany(t => t.TaskLinks).HasForeignKey(v => v.AssignedTo);
            builder.HasOne(b => b.Competition).WithMany(t => t.TaskLinks).HasForeignKey(v => v.CompetitionId);
        }
    }
}
