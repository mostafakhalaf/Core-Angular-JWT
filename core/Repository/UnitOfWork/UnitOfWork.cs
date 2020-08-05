using MostafaKhalafFullStack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MostafaKhalafFullStack.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly AppDbContext Context;
        public UnitOfWork(AppDbContext Context)
        {
            this.Context = Context;
        }
        public void Complete()
        {
            Context.SaveChanges();
        }
    }
}
