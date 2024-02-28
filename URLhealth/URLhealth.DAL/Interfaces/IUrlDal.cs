using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLhealth.Core.DataAccess;
using URLhealth.Entities.Concrete;
using URLhealth.Entities.DTO;

namespace URLhealth.DAL.Interfaces
{
    public interface IUrlDal : IEntityRepository<URL>
    {
        List<URL> GetAllByUserID(int userId);
        List<UrlDTO> GetAllDTO();
        List<UrlDTO> GetAllDTO(int userId);
    }
}
