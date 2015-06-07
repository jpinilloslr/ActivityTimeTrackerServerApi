using ATTServerApi.Data.Contracts;
using ATTServerApi.Data.Repositories;

namespace ATTServerApi.Data
{
    public class AttUow : IAttUow
    {
        private readonly IActivityConceptRepository _activityConceptRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IFilterRuleRepository _filterRuleRepository;
        private readonly AttDbContext _dbContext;

        public IActivityConceptRepository ActivityConcepts
        {
            get { return _activityConceptRepository; }
        }

        public IActivityRepository Activities
        {
            get { return _activityRepository; }
        }

        public IFilterRuleRepository FilterRules
        {
            get { return _filterRuleRepository; }
        }

        public AttUow()
        {
            _dbContext = new AttDbContext();
            _activityConceptRepository = new ActivityConceptRepository(_dbContext);            
            _filterRuleRepository = new FilterRuleRepository(_dbContext);
            _activityRepository = new ActivityRepository(_dbContext);            
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
