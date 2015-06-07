using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATTServerApi.Data.Contracts;
using ATTServerApi.Model;

namespace ATTServerApi.Data.Repositories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly AttDbContext _dbContext;

        public RepositoryFactory(DbContext dbContext)
        {
            _dbContext = (AttDbContext) dbContext;
        }

        public IActivityConceptRepository CreateActivityConceptRepository()
        {
            return new ActivityConceptRepository(_dbContext);
        }

        public IActivityRepository CreateActivityRepository()
        {
            return new ActivityRepository(_dbContext);
        }

        public IFilterRuleRepository CreatFilterRuleRepository()
        {
            return new FilterRuleRepository(_dbContext);
        }
    }
}
