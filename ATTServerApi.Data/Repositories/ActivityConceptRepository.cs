using System.Data.Entity;
using System.Linq;
using ATTServerApi.Data.Contracts;
using ATTServerApi.Model;

namespace ATTServerApi.Data.Repositories
{
    public class ActivityConceptRepository : EFRepository<ActivityConcept>, IActivityConceptRepository
    {
        public ActivityConceptRepository(DbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<ActivityConcept> GetAllWithRules()
        {
            return DbContext.Set<ActivityConcept>().Include("Rules");
        }

        public ActivityConcept GetByIdWithRules(int id)
        {
            return GetAllWithRules().FirstOrDefault(a => a.Id == id);
        }
    }
}
