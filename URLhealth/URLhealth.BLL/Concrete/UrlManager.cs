using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLhealth.BLL.Interfaces;
using URLhealth.DAL.Interfaces;
using URLhealth.Entities.Concrete;
using URLhealth.Entities.DTO;

namespace URLhealth.BLL.Concrete
{
    public class UrlManager : IUrlService
    {
        private readonly IUrlDal _iUrlDal;

        public UrlManager(IUrlDal iUrlDal)
        {
            _iUrlDal = iUrlDal;
        }

        public int Add(URL instance)
        {
            bool success = _iUrlDal.Add(instance);
            return success ? instance.ID : 0;
        }

        public int Delete(int id)
        {
            bool success = false;
            if (id > 0)
                success = _iUrlDal.Delete(new URL { ID = id });
            return success ? id : 0;
        }

        public List<URL> GetAll()
        {
            return _iUrlDal.GetList();
        }

        public List<URL> GetAllByUserID(int userId)
        {
            return _iUrlDal.GetAllByUserID(userId);
        }

        public List<UrlDTO> GetAllDTO()
        {
            return _iUrlDal.GetAllDTO();
        }

        public List<UrlDTO> GetAllDTO(int userId)
        {
            return _iUrlDal.GetAllDTO(userId);
        }

        public URL GetById(int id)
        {
            return _iUrlDal.Get(x => x.ID == id);
        }

        public int Update(URL instance)
        {
            bool success = _iUrlDal.Update(instance);
            return success ? instance.ID : 0;
        }
    }
}
