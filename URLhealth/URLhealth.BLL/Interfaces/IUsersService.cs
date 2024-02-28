using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLhealth.Entities.Concrete;

namespace URLhealth.BLL.Interfaces
{
    public interface IUsersService
    {
        int Add(USERS instance);
        int Update(USERS instance);
        int Delete(int id);
        List<USERS> GetAll();
        USERS GetById (int id);
    }
}
