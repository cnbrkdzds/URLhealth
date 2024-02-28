using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLhealth.BLL.Interfaces;
using URLhealth.DAL.Interfaces;
using URLhealth.Entities.Concrete;

namespace URLhealth.BLL.Concrete
{
    public class UsersManager : IUsersService
    {
        private IUsersDal _iUsersDal;

        public UsersManager(IUsersDal iUsersDal)
        {
            _iUsersDal = iUsersDal;
        }

        public int Add(USERS instance)
        {
            bool success = _iUsersDal.Add(instance);
            return success ? instance.ID : 0;
        }

        public int Delete(int id)
        {
            bool success = false;
            if (id > 0)
                success = _iUsersDal.Delete(new USERS { ID = id });
            return success ? id : 0;
        }

        public List<USERS> GetAll()
        {
            return _iUsersDal.GetList();
        }

        public USERS GetById(int id)
        {
            return _iUsersDal.Get(x => x.ID == id);
        }

        public int Update(USERS instance)
        {
            bool success = _iUsersDal.Update(instance);
            return success ? instance.ID : 0;
        }
    }
}
