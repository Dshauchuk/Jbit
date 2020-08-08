using Jbit.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jbit.API.Data.Mapping
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("persons");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasColumnName("id");
            builder.Property(e => e.FirstName).IsRequired().HasColumnName("first_name");
            builder.Property(e => e.LastName).IsRequired().HasColumnName("last_name");
            builder.Property(e => e.Email).HasColumnName("email");
            builder.Property(e => e.Avatar).HasColumnName("avatar");
            builder.Property(e => e.OwnerId).IsRequired().HasColumnName("owner_id");
            //builder.Property(e => e.UserId).HasColumnName("user_id");
            builder.Property(e => e.Points).IsRequired().HasColumnName("points");
            
            builder.HasMany(b => b.TaskLinks).WithOne(t => t.Person).HasForeignKey(t => t.AssignedTo);
            builder.HasMany(b => b.CompetitionLinks).WithOne(l => l.Person).HasForeignKey(t => t.PersonId);
        }
    }
}
