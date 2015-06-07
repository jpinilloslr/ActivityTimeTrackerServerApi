using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ATTServerApi.Model;

namespace ATTServerApi.Data
{
    public class AttDbContext : DbContext
    {
        public AttDbContext()
            : base(nameOrConnectionString: "DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityConcept> ActivityConcepts { get; set; }
        public DbSet<FilterRule> FilterRules { get; set; }

        
    }
}
