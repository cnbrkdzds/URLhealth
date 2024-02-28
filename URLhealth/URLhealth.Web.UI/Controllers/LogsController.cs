using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using URLhealth.BLL.Interfaces;
using URLhealth.Entities.Concrete;

namespace URLhealth.Web.UI.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogsService _iLogsService;
        private readonly IUsersService _iUsersService;

        private readonly IHttpContextAccessor _contextAccessor;

        public LogsController(ILogsService iLogsService, IUsersService iUsersService, IHttpContextAccessor contextAccessor)
        {
            _iLogsService = iLogsService;
            _iUsersService = iUsersService;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            List<LOGS> list = _iLogsService.GetAll();
            return View(list);
        }
    }
}
