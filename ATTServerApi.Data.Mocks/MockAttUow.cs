using ATTServerApi.Data.Contracts;
using ATTServerApi.Data.Mocks.Repositories;

namespace ATTServerApi.Data.Mocks
{
    public class MockAttUow : IAttUow
    {
        private readonly IActivityConceptRepository _activityConceptRepository = new MockActivityConceptRepository();
        private readonly IActivityRepository _activityRepository = new MockActivityRepository();
        private readonly IFilterRuleRepository _filterRuleRepository = new MockFilterRuleRepository();

        public void Dispose()
        {
            
        }

        public void Commit()
        {
            
        }

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
    }
}
