using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using URLhealth.BLL.Interfaces;
using URLhealth.Entities.Concrete;
using URLhealth.Entities.DTO;
using URLhealth.Web.UI.Models;
using URLhealth.Web.UI.Services;

namespace URLhealth.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly IHttpContextAccessor _contextAccessor;

        private readonly IUsersService _iUsersService;
        private readonly IUrlService _iUrlService;
        private readonly ILogsService _iLogsService;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor contextAccessor, IUrlService iUrlService, IUsersService iUsersService, ILogsService iLogsService)
        {
            _logger = logger;

            _contextAccessor = contextAccessor;

            _iUrlService = iUrlService;
            _iUsersService = iUsersService;
            _iLogsService = iLogsService;
        }

        public IActionResult Index()
        {
            List<UrlDTO> list = new List<UrlDTO>();
            try
            {
                string SessionValue = _contextAccessor.HttpContext.Session.GetString("SessionManager");
                if (SessionValue != null)
                {
                    USERS sessionManager = JsonConvert.DeserializeObject<USERS>(SessionValue);
                    if (sessionManager != null)
                    {
                        list = _iUrlService.GetAllDTO(sessionManager.ID);
                        PingService.list = list;
                    }
                }
            }
            catch (Exception sessionCatch) 
            {
                LOGS log = LOGS.GetInstance();
                log.URL = "/Home/Index";
                log.LEVEL = "Session Error";
                log.MESSAGE = sessionCatch.Message;
                log.CREATED_DATE = DateTime.Now;
                _iLogsService.AddAsync(log);
            }

            return View(list);
        }


        #region Users Operations
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool success = false;
            try
            {
                string SessionValue = _contextAccessor.HttpContext.Session.GetString("SessionManager");
                if (SessionValue != null)
                {
                    USERS sessionManager = JsonConvert.DeserializeObject<USERS>(SessionValue);
                    if (sessionManager != null)
                    {
                        success = _iUsersService.Delete(id) > 0;
                    }
                }
            }
            catch (Exception sessionCatch) {

                LOGS log = LOGS.GetInstance();
                log.URL = "/Home/Delete";
                log.LEVEL = "Session Error";
                log.MESSAGE = sessionCatch.Message;
                log.CREATED_DATE = DateTime.Now;
                _iLogsService.AddAsync(log);
            }

            return Json(new { success = success });
        }

        #endregion


        #region URL Operations

        [HttpPost]
        public JsonResult AddUrl(URL instance)
        {
            bool success = false;
            try
            {
                string SessionValue = _contextAccessor.HttpContext.Session.GetString("SessionManager");
                if (SessionValue != null)
                {
                    USERS sessionManager = JsonConvert.DeserializeObject<USERS>(SessionValue);
                    if (sessionManager != null)
                    {
                        instance.USER_ID = sessionManager.ID;
                        success = _iUrlService.Add(instance) > 0;

                        if (success)
                            PingService.list = _iUrlService.GetAllDTO(sessionManager.ID);
                    }
                }
            }
            catch (Exception sessionCatch)
            {
                LOGS log = LOGS.GetInstance();
                log.URL = "/Home/AddUrl";
                log.LEVEL = "Session Error";
                log.MESSAGE = sessionCatch.Message;
                log.CREATED_DATE = DateTime.Now;
                _iLogsService.AddAsync(log);
            }

            return Json(new { success = success });
        }
        [HttpPost]
        public JsonResult UpdateUrl(URL instance)
        {
            bool success = false;
            try
            {
                string SessionValue = _contextAccessor.HttpContext.Session.GetString("SessionManager");
                if (SessionValue != null)
                {
                    USERS sessionManager = JsonConvert.DeserializeObject<USERS>(SessionValue);
                    if (sessionManager != null)
                    {
                        instance.USER_ID = sessionManager.ID;
                        success = _iUrlService.Update(instance) > 0;
                        if (success)
                            PingService.list = _iUrlService.GetAllDTO(sessionManager.ID);
                    }
                }
            }
            catch (Exception sessionCatch)
            {
                LOGS log = LOGS.GetInstance();
                log.URL = "/Home/UpdateUrl";
                log.LEVEL = "Session Error";
                log.MESSAGE = sessionCatch.Message;
                log.CREATED_DATE = DateTime.Now;
                _iLogsService.AddAsync(log);
            }

            return Json(new { success = success });
        }

        [HttpPost]
        public JsonResult DeleteUrl(int id)
        {
            bool success = false;
            try
            {
                string SessionValue = _contextAccessor.HttpContext.Session.GetString("SessionManager");
                if (SessionValue != null)
                {
                    USERS sessionManager = JsonConvert.DeserializeObject<USERS>(SessionValue);
                    if (sessionManager != null)
                    {
                        success = _iUrlService.Delete(id) > 0;
                    }
                }
            }
            catch (Exception sessionCatch)
            {
                LOGS log = LOGS.GetInstance();
                log.URL = "/Home/DeleteUrl";
                log.LEVEL = "Session Error";
                log.MESSAGE = sessionCatch.Message;
                log.CREATED_DATE = DateTime.Now;
                _iLogsService.AddAsync(log);
            }

            return Json(new { success = success });
        }


        [HttpGet]
        public JsonResult GetByIdUrl(int id)
        {
            URL instance = _iUrlService.GetById(id);
            return Json(instance);
        }
        #endregion


        #region SignUp SignIn Logout Operations


        [HttpPost]
        public JsonResult SignUp(USERS instance)
        {
            bool success = false;
            try
            {
                List<USERS> allList = _iUsersService.GetAll().Where(x => x.MAIL == instance.MAIL).ToList();

                if (allList.Count == 0)
                {
                    int rID = _iUsersService.Add(instance);
                    success = rID > 0;
                    instance.ID = rID;
                    _contextAccessor.HttpContext.Session.SetString("SessionManager", JsonConvert.SerializeObject(instance));
                }
            }
            catch (Exception expSignUp)
            {
                LOGS log = LOGS.GetInstance();
                log.URL = "/Home/SignUp";
                log.LEVEL = "Sign Up Error";
                log.MESSAGE = expSignUp.Message;
                log.CREATED_DATE = DateTime.Now;
                _iLogsService.AddAsync(log);
            }

            return Json(new { success = success });
        }

        [HttpPost]
        public JsonResult SignIn(string MAIL)
        {
            bool success = false;
            try
            {
                USERS instance = _iUsersService.GetAll().Where(x => x.MAIL == MAIL).SingleOrDefault();
                if (instance != null)
                {
                    _contextAccessor.HttpContext.Session.SetString("SessionManager", JsonConvert.SerializeObject(instance));
                    success = true;
                }
            }
            catch(Exception expSignIn)
            {

                LOGS log = LOGS.GetInstance();
                log.URL = "/Home/SignIn";
                log.LEVEL = "Sign In Error";
                log.MESSAGE = expSignIn.Message;
                log.CREATED_DATE = DateTime.Now;
                _iLogsService.AddAsync(log);
            }

            return Json(new { success = success });
        }

        #endregion


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
