using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLhealth.Core.DataAccess.EntityFramework;
using URLhealth.DAL.Interfaces;
using URLhealth.Entities.Concrete;
using URLhealth.Entities.DTO;

namespace URLhealth.DAL.Concrete
{
    public class EfUrlDal : EfEntityRepositoryBase<URL, URLhealthContext>, IUrlDal
    {
        public List<URL> GetAllByUserID(int userId)
        {
            using (URLhealthContext _context = new URLhealthContext())
            {
                List<URL> listDTO = (from url in _context.Url
                                     where url.USER_ID == userId
                                     select new URL
                                     {
                                         ID = url.ID,
                                         TIMER = url.TIMER,
                                         USER_ID = url.USER_ID,
                                         URL_LINK = url.URL_LINK
                                     }).ToList();
                return listDTO;
            }
        }

        public List<UrlDTO> GetAllDTO()
        {
            using (URLhealthContext _context = new URLhealthContext())
            {
                List<UrlDTO> listDTO = (from url in _context.Url

                                        join user in _context.Users on url.USER_ID equals user.ID into sr
                                        from user in sr.DefaultIfEmpty()

                                        select new UrlDTO
                                        {
                                            ID = url.ID,
                                            TIMER = url.TIMER,
                                            USER_ID = url.USER_ID,
                                            URL_LINK = url.URL_LINK,
                                            UserMail = user.MAIL
                                        }).ToList();
                return listDTO;
            }
        }

        public List<UrlDTO> GetAllDTO(int userId)
        {
            using (URLhealthContext _context = new URLhealthContext())
            {
                List<UrlDTO> listDTO = (from url in _context.Url

                                        join user in _context.Users on url.USER_ID equals user.ID into sr
                                        from user in sr.DefaultIfEmpty()

                                        where url.USER_ID == userId

                                        select new UrlDTO
                                        {
                                            ID = url.ID,
                                            TIMER = url.TIMER,
                                            USER_ID = url.USER_ID,
                                            URL_LINK = url.URL_LINK,
                                            UserMail = user.MAIL
                                        }).ToList();
                return listDTO;
            }
        }
    }
}
