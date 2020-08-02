using Jbit.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jbit.API.Data.Mapping
{
    public class CompetitionMapping : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder.ToTable("competitions");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasColumnName("id");
            builder.Property(e => e.Name).IsRequired().HasColumnName("title");
            builder.Property(e => e.Description).HasColumnName("description");
            builder.Property(e => e.OwnerId).IsRequired().HasColumnName("owner_id");

            builder.HasOne(b => b.Owner).WithMany(t => t.Competitions).HasForeignKey(c => c.OwnerId);
            builder.HasMany(b => b.TaskLinks).WithOne(t => t.Competition).HasForeignKey(t => t.CompetitionId);
            builder.HasMany(b => b.PersonLinks).WithOne(t => t.Competition).HasForeignKey(t => t.CompetitionId);
        }
    }
}
