using System.Data.Entity;
using ATTServerApi.Data.Contracts;
using ATTServerApi.Model;

namespace ATTServerApi.Data.Repositories
{
    public class FilterRuleRepository : EFRepository<FilterRule>, IFilterRuleRepository
    {
        public FilterRuleRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
