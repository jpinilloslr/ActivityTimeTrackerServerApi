using System.Collections.Generic;
using System.Linq;
using ATTServerApi.Data.Contracts;
using ATTServerApi.Model;

namespace ATTServerApi.Data.Mocks.Repositories
{
    public class MockActivityConceptRepository : IActivityConceptRepository
    {
        private readonly List<ActivityConcept> _list = new List<ActivityConcept>();

        public MockActivityConceptRepository()
        {
            _list = new List<ActivityConcept>
            {
                new ActivityConcept() {Description = "Desc1", Id = 1, Name = "ActivityConcept1", Rules = new List<FilterRule>()
                {
                    new FilterRule(){Id = 1, Name = "Filter1", Expression = "processName == \"process1\"", Description = "Desc1"}
                }},
                new ActivityConcept() {Description = "Desc2", Id = 2, Name = "ActivityConcept2", Rules = new List<FilterRule>()
                {
                    new FilterRule(){Id = 2, Name = "Filter2", Expression = "processName == \"process2\"", Description = "Desc2"}
                }},
                new ActivityConcept() {Description = "Desc3", Id = 3, Name = "ActivityConcept3", Rules = new List<FilterRule>()
                {
                    new FilterRule(){Id = 3, Name = "Filter3", Expression = "processName == \"process3\"", Description = "Desc3"}
                }}
            };
        }

        public IQueryable<ActivityConcept> GetAllWithRules()
        {
            return _list.AsQueryable();
        }

        public ActivityConcept GetByIdWithRules(int id)
        {
            return GetAllWithRules().FirstOrDefault(a => a.Id == id);
        }

        public IQueryable<ActivityConcept> GetAll()
        {
            return _list.AsQueryable();
        }

        public IQueryable<ActivityConcept> GetAllWithInclude(string relation)
        {
            return _list.AsQueryable();
        }

        public List<ActivityConcept> GetBySQL(string sql)
        {
            return _list;
        }

        public ActivityConcept GetById(int id)
        {
            return _list.FirstOrDefault(m => m.Id == id);
        }

        public void Add(ActivityConcept entity)
        {
            _list.Add(entity);
        }

        public void Update(ActivityConcept entity)
        {
            var entry = GetById(entity.Id);
            if (entry != null)
            {
                _list.Remove(entry);
                _list.Add(entity);
            }
        }

        public void Delete(ActivityConcept entity)
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
