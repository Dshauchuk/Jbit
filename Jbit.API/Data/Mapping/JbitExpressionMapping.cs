using Jbit.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jbit.API.Data.Mapping
{
    public class JbitExpressionMapping : IEntityTypeConfiguration<JbitExpression>
    {
        public void Configure(EntityTypeBuilder<JbitExpression> builder)
        {
            builder.ToTable("expressions");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasColumnName("id");
            builder.Property(e => e.Name).IsRequired().HasColumnName("name");
            builder.Property(e => e.ExpressionString).IsRequired().HasColumnName("exp_string");
            builder.Property(e => e.Description).HasColumnName("description");

            builder.HasMany(t => t.Competitions).WithOne(a => a.Expression).HasForeignKey(t => t.ExpressionId);
        }
    }
}
