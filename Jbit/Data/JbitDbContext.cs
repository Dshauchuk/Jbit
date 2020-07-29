using Jbit.Common.Models;
using Jbit.Web.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Jbit.Web.Data
{
    public class JbitDbContext : DbContext
    {
        public JbitDbContext(DbContextOptions<JbitDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PersonTask> Tasks { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamPerson> TeamPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("_jbit");

            modelBuilder
                .ApplyConfiguration(new PersonTaskMapping())
                .ApplyConfiguration(new TeamPersonMapping())
                .ApplyConfiguration(new TeamMapping())
                .ApplyConfiguration(new PersonMapping());
        }
    }
}
