using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MostafaKhalafFullStack.Repository.Generic
{
   public interface IGRepository<T> where T : class
    {

        void Add(T entity);
        void  Remove(T entity);
        IEnumerable<T> GetAll();
        T Find(params object[] keys);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        T GetFirst();
    }
}
