using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLhealth.Core.Utilities.Abstract;
using URLhealth.Entities.Concrete;

namespace URLhealth.BLL.Interfaces
{
    public interface ILogsService
    {
        long Add(LOGS instance);
        long Update(LOGS instance);
        long Delete(long id);
        List<LOGS> GetAll();
        LOGS GetById(long id);

        Task<IResult> AddAsync(LOGS logs);
    }
}
