using Jbit.API.Data.Mapping;
using Jbit.Common.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jbit.API.Data
{
    public class JbitDbContext : DbContext
    {
        public JbitDbContext(DbContextOptions<JbitDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<TaskValue> TaskValues { get; set; }
        public virtual DbSet<JbitTask> Tasks { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<CompetitionPerson> CompetitionPersons { get; set; }
        public virtual DbSet<Identity> Identities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<JbitExpression> Expressions { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLoggerFactory(MyLoggerFactory);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("_jbit");

            modelBuilder
                .ApplyConfiguration(new TaskValueMapping())
                .ApplyConfiguration(new JbitTaskMapping())
                .ApplyConfiguration(new JbitExpressionMapping())
                .ApplyConfiguration(new PersonMapping())
                .ApplyConfiguration(new CompetitionMapping())
                .ApplyConfiguration(new CompetitionPersonMapping())
                .ApplyConfiguration(new IdentityMapping())
                .ApplyConfiguration(new UserMapping());
        }
    }
}
