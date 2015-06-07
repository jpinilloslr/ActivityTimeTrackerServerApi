using System;
using System.Collections.Generic;
using System.Linq;
using ATTServerApi.Data.Contracts;
using ATTServerApi.Model;

namespace ATTServerApi.Data.Mocks.Repositories
{
    public class MockActivityRepository : IActivityRepository
    {
        private readonly List<Activity> _list = new List<Activity>();

        public MockActivityRepository()
        {
            _list = new List<Activity>
            {
                new Activity() {Date = DateTime.Now, Id = 1, ModuleFilename = "module1", Life = 2, ProcessName = "process1", WindowText = "text1"},
                new Activity() {Date = DateTime.Now, Id = 2, ModuleFilename = "module1", Life = 2, ProcessName = "process1", WindowText = "text1"},

                new Activity() {Date = DateTime.Now, Id = 3, ModuleFilename = "module2", Life = 2, ProcessName = "process2", WindowText = "text2"},
                new Activity() {Date = DateTime.Now, Id = 4, ModuleFilename = "module2", Life = 2, ProcessName = "process2", WindowText = "text2"},

                new Activity() {Date = DateTime.Now, Id = 5, ModuleFilename = "module3", Life = 2, ProcessName = "process3", WindowText = "text3"},
                new Activity() {Date = DateTime.Now, Id = 6, ModuleFilename = "module3", Life = 2, ProcessName = "process3", WindowText = "text3"},
            };
        }

        public IQueryable<Activity> GetAll()
        {
            return _list.AsQueryable();
        }

        public IQueryable<Activity> GetAllWithInclude(string relation)
        {
            return _list.AsQueryable();
        }

        public List<Activity> GetBySQL(string sql)
        {
            return _list;
        }

        public Activity GetById(int id)
        {
            return _list.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Activity entity)
        {
            _list.Add(entity);
        }

        public void Update(Activity entity)
        {
            var entry = GetById(entity.Id);
            if (entry != null)
            {
                _list.Remove(entry);
                _list.Add(entity);
            }
        }

        public void Delete(Activity entity)
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
