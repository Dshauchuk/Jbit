using Jbit.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jbit.API.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasColumnName("id");
            builder.Property(e => e.FirstName).IsRequired().HasColumnName("first_name");
            builder.Property(e => e.LastName).IsRequired().HasColumnName("last_name");
            builder.Property(e => e.Email).IsRequired().HasColumnName("email");
            builder.Property(e => e.PasswordHash).IsRequired().HasColumnName("password_hash");
            builder.Property(e => e.RegistrationTimestamp).IsRequired().HasColumnName("registration_timestamp");

            builder.HasMany(t => t.UserLogins).WithOne(i => i.User).HasForeignKey(i => i.UserId);
            builder.HasMany(b => b.CreatedPersons).WithOne(p => p.Owner).HasForeignKey(p => p.OwnerId);
        }
    }
}
