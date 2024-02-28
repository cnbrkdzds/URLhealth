using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLhealth.Core.DataAccess;
using URLhealth.Entities.Concrete;

namespace URLhealth.DAL.Interfaces
{
    public interface ILogsDal : IEntityRepository<LOGS>
    {
    }
}
