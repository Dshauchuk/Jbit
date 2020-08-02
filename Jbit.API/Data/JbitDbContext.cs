using Jbit.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Jbit.API.Data
{
    public class JbitDbContext : DbContext
    {
        public JbitDbContext(DbContextOptions<JbitDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<TaskValue> TaskValues { get; set; }
        public virtual DbSet<JbitTask> PersonTasks { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Competition> Competitions{ get; set; }
        public virtual DbSet<CompetitionPerson> CompetitionPersons{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("_jbit");

            modelBuilder
                .ApplyConfiguration(new ApplicationDomainMapping())
                .ApplyConfiguration(new DomainAssociationMapping())
                .ApplyConfiguration(new DomainModuleMapping())
                .ApplyConfiguration(new ApplicationDomainAuthOptionsMapping())
                .ApplyConfiguration(new DomainActivityMapping())
                .ApplyConfiguration(new FunctionMapping())
                .ApplyConfiguration(new FunctionPermissionMapping())
                .ApplyConfiguration(new PermissionMapping())
                .ApplyConfiguration(new RoleFunctionMapping())
                .ApplyConfiguration(new RoleMapping())
                .ApplyConfiguration(new RolePermissionMapping())
                .ApplyConfiguration(new UserActivityMapping())
                .ApplyConfiguration(new UserMapping())
                .ApplyConfiguration(new UserLoginMapping())
                .ApplyConfiguration(new UserRoleMapping())
                .ApplyConfiguration(new PersistedGrantMapping());
        }
    }
}
