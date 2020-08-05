using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MostafaKhalafFullStack.Repository.UnitOfWork
{
   public interface IUnitOfWork
    {
       void Complete();
    }
}
