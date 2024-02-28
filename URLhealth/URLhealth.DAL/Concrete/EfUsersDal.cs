using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLhealth.Core.DataAccess.EntityFramework;
using URLhealth.DAL.Interfaces;
using URLhealth.Entities.Concrete;

namespace URLhealth.DAL.Concrete
{
    public class EfUsersDal : EfEntityRepositoryBase<USERS, URLhealthContext>, IUsersDal
    {
    }
}
