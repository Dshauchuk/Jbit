using Jbit.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jbit.API.Data.Mapping
{
    public class TaskValueMapping : IEntityTypeConfiguration<TaskValue>
    {
        public void Configure(EntityTypeBuilder<TaskValue> builder)
        {
            builder.ToTable("task_values");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired().HasColumnName("id");
            builder.Property(e => e.Name).IsRequired().HasColumnName("name");
            builder.Property(e => e.Value).IsRequired().HasColumnName("value");
            builder.Property(e => e.TaskId).IsRequired().HasColumnName("task_id");

            builder.HasOne(b => b.Task).WithMany(t => t.Values).HasForeignKey(v => v.TaskId);
        }
    }
}
