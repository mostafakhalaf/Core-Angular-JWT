using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MostafaKhalafFullStack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MostafaKhalafFullStack.Repository.Generic
{
    public class Repository<T> : IGRepository<T> where T : class
    {
        protected readonly AppDbContext dbContext;
        public Repository(AppDbContext dbContext)
        {

            this.dbContext = dbContext;
        }
        public void Add(T entity)
        {

             dbContext.Set<object>().Add(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().AsNoTracking().ToList<T>();
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            dbContext.Set<T>().AddRange(entities);
        }

        public virtual T GetFirst()
        {
            return dbContext.Set<T>().AsNoTracking().FirstOrDefault();
        }
        public T Find(params object[] keys)
        {
            var m = dbContext.Set<T>().Find(keys);
            return dbContext.Set<T>().Find(keys);
        }

        public void Remove(T entity)
        {
             dbContext.Remove(entity);
        }

        public void Update(T entity)
        {
            foreach (var entry in dbContext.ChangeTracker.Entries<T>().ToList())
            {
                entry.State = EntityState.Detached;
            }
             dbContext.Update(entity);
        }
    }
}
