using Jbit.Common.Models;
using Jbit.Web.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Jbit.Web.Data
{
    public class JbitDbContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory 
            = LoggerFactory.Create(builder =>
               {
                   builder
                    .AddFilter((category, level) =>
                        category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information)
                    .AddConsole();
               });

        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public JbitDbContext(DbContextOptions<JbitDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .UseLoggerFactory(ConsoleLoggerFactory);

        public virtual DbSet<PersonTask> Tasks { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamPerson> TeamPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("_jbit");

            modelBuilder
                .ApplyConfiguration(new PersonTaskMapping())
                .ApplyConfiguration(new TeamMapping())
                .ApplyConfiguration(new TeamPersonMapping())
                .ApplyConfiguration(new PersonMapping());
        }
    }
}
