using Jbit.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jbit.API.Data.Mapping
{
    public class IdentityMapping : IEntityTypeConfiguration<Identity>
    {
        public void Configure(EntityTypeBuilder<Identity> builder)
        {
            builder.ToTable("user_logins");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasColumnName("id");
            builder.Property(e => e.DeviceId).IsRequired().HasColumnName("device_id");
            builder.Property(e => e.Device).IsRequired().HasColumnName("device");
            builder.Property(e => e.AccessToken).IsRequired().HasColumnName("access_token");
            builder.Property(e => e.RefreshToken).IsRequired().HasColumnName("refresh_token");
            builder.Property(e => e.UpdateTimestamp).IsRequired().HasColumnName("update_timestamp");
            builder.Property(e => e.UserId).IsRequired().HasColumnName("user_id");

            builder.HasOne(b => b.User).WithMany(t => t.UserLogins).HasForeignKey(v => v.UserId);
        }
    }
}
