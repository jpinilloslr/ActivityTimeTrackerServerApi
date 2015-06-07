using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using ATTServerApi.Data.Contracts;

namespace ATTServerApi.Data.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public EFRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        protected DbContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public IQueryable<T> GetAllWithInclude(string relation)
        {
            return DbSet.Include(relation);
        }

        public List<T> GetBySQL(string sql)
        {
            var a = DbContext.Set<T>().SqlQuery(sql);
            
            return a.ToList();
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Add(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public void Update(T entity)
        {
            
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
            }
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if(entity != null)
                Delete(entity);
        }
    }
}
