using Jbit.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jbit.Web.Data.Mapping
{
    public class PersonTaskMapping : IEntityTypeConfiguration<PersonTask>
    {
        public void Configure(EntityTypeBuilder<PersonTask> builder)
        {
            builder.ToTable("tasks");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasColumnName("id");
            builder.Property(e => e.Title).IsRequired().HasColumnName("title");
            builder.Property(e => e.AssignedTo).IsRequired().HasColumnName("assigned_to");
            builder.Property(e => e.Hours).IsRequired().HasColumnName("hours");
            builder.Property(e => e.Link).HasColumnName("link");
            builder.Property(e => e.FatalErrors).IsRequired().HasColumnName("fatal_errors");
            builder.Property(e => e.Corrections).IsRequired().HasColumnName("corrections_num");
        }
    }
}
