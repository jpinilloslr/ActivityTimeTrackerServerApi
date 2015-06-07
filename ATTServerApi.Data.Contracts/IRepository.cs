using System;
using System.Collections.Generic;
using System.Linq;

namespace ATTServerApi.Data.Contracts
{
    public interface IRepository<T> where T : class 
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetAllWithInclude(string relation);

        List<T> GetBySQL(string sql);

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(int id);

    }
}
