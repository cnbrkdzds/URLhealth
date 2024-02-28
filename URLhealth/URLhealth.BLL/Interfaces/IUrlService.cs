using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLhealth.Entities.Concrete;
using URLhealth.Entities.DTO;

namespace URLhealth.BLL.Interfaces
{
    public interface IUrlService
    {
        int Add(URL instance);
        int Update(URL instance);
        int Delete(int id);
        List<URL> GetAll();
        URL GetById(int id);


        List<UrlDTO> GetAllDTO();
        List<UrlDTO> GetAllDTO(int userId);
        List<URL> GetAllByUserID(int userId);
    }
}
