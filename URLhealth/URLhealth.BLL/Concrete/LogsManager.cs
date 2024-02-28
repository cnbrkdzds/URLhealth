using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLhealth.BLL.Interfaces;
using URLhealth.Core.Utilities.Abstract;
using URLhealth.Core.Utilities.ComplexTypes;
using URLhealth.Core.Utilities.Concrete;
using URLhealth.DAL.Interfaces;
using URLhealth.Entities.Concrete;

namespace URLhealth.BLL.Concrete
{
    public class LogsManager : ILogsService
    {
        private readonly ILogsDal _iLogsDal;

        public LogsManager(ILogsDal iLogsDal)
        {
            _iLogsDal = iLogsDal;
        }

        public long Add(LOGS instance)
        {
            bool success = _iLogsDal.Add(instance);
            return success ? instance.ID : 0;
        }

        public async Task<IResult> AddAsync(LOGS logs)
        {
            await _iLogsDal.AddAsync(logs);
            return new Result(ResultStatus.Succes, "Log başarıyla eklenmiştir");
        }
        public long Delete(long id)
        {
            bool success = false;
            if (id > 0)
                success = _iLogsDal.Delete(new LOGS { ID = id });
            return success ? id : 0;
        }

        public List<LOGS> GetAll()
        {
            return _iLogsDal.GetList();
        }

        public LOGS GetById(long id)
        {
            return _iLogsDal.Get(x => x.ID == id);
        }

        public long Update(LOGS instance)
        {
            bool success = _iLogsDal.Update(instance);
            return success ? instance.ID : 0;
        }
    }
}
