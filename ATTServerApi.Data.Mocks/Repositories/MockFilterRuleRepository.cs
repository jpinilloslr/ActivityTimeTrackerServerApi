using System.Collections.Generic;
using System.Linq;
using ATTServerApi.Data.Contracts;
using ATTServerApi.Model;

namespace ATTServerApi.Data.Mocks.Repositories
{
    public class MockFilterRuleRepository : IFilterRuleRepository
    {
        private readonly List<FilterRule> _list = new List<FilterRule>();

        public MockFilterRuleRepository()
        {
            _list = new List<FilterRule>
            {
                new FilterRule() {Id = 1, Name = "Filter1", Description = "Desc1", Expression = "processName == \"process1\"", ActivityConcepts = new List<ActivityConcept>()
                {
                    new ActivityConcept() {Description = "Desc1", Id = 1, Name = "ActivityConcept1"}
                }},
                new FilterRule() {Id = 2, Name = "Filter2", Description = "Desc2", Expression = "processName == \"process2\"", ActivityConcepts = new List<ActivityConcept>()
                {
                    new ActivityConcept() {Description = "Desc2", Id = 2, Name = "ActivityConcept2"}
                }},
                new FilterRule() {Id = 3, Name = "Filter3", Description = "Desc3", Expression = "processName == \"process3\"", ActivityConcepts = new List<ActivityConcept>()
                {
                    new ActivityConcept() {Description = "Desc3", Id = 3, Name = "ActivityConcept3"}
                }},
            };
        }

        public IQueryable<FilterRule> GetAll()
        {
            return _list.AsQueryable();
        }

        public IQueryable<FilterRule> GetAllWithInclude(string relation)
        {
            return _list.AsQueryable();
        }

        public List<FilterRule> GetBySQL(string sql)
        {
            return _list;
        }

        public FilterRule GetById(int id)
        {
            return _list.FirstOrDefault(m => m.Id == id);
        }

        public void Add(FilterRule entity)
        {
            _list.Add(entity);
        }

        public void Update(FilterRule entity)
        {
            var entry = GetById(entity.Id);
            if (entry != null)
            {
                _list.Remove(entry);
                _list.Add(entity);
            }
        }

        public void Delete(FilterRule entity)
        {
            _list.Remove(entity);
        }

        public void Delete(int id)
        {
            var entry = GetById(id);
            _list.Remove(entry);
        }

        public void Dispose()
        {
            
        }
    }
}
