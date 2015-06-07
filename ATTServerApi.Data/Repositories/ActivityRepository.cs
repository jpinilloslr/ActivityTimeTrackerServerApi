using System.Data.Entity;
using ATTServerApi.Data.Contracts;
using ATTServerApi.Model;

namespace ATTServerApi.Data.Repositories
{
    public class ActivityRepository : EFRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
