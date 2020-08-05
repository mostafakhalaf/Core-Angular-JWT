using MostafaKhalafFullStack.Model;
using MostafaKhalafFullStack.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MostafaKhalafFullStack.Service.Iservice
{
    public interface IServiceUser
    {
         void PostUser(ApplicationUser model);
        IEnumerable<ApplicationUser> GetAllUser();
        void EditUser(ApplicationUser model);
        void DeleteUser(ApplicationUser model);
        ApplicationUser GetByIDUser(object id);
    }
}
