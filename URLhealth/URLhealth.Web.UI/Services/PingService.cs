using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using URLhealth.BLL.Interfaces;
using URLhealth.DAL.Concrete;
using URLhealth.Entities.Concrete;
using URLhealth.Entities.DTO;
using URLhealth.UTILITIES.MailManager;
using URLhealth.Web.UI.MyHubs;

namespace URLhealth.Web.UI.Services
{
    public class PingService : BackgroundService
    {
        private readonly ILogsService _iLogsService;

        private readonly IUrlService _iUrlService;
        private readonly IHubContext<UrlHubs> _hubContext;

        private readonly IHttpContextAccessor _contextAccessor;

        public static List<UrlDTO> list = new List<UrlDTO>();
        USERS sessionManager = null;
        public PingService(IHubContext<UrlHubs> hubContext, IUrlService iUrlService, IHttpContextAccessor contextAccessor, ILogsService iLogsService)
        {
            _hubContext = hubContext;
            _iUrlService = iUrlService;
            _contextAccessor = contextAccessor;
            _iLogsService = iLogsService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if(list.Count > 0)
                {
                    foreach (UrlDTO item in list)
                    {
                        bool send = false;
                        if (item.LastPingDate == null)
                            send = true;
                        else
                        {
                            double minFromLastPing = (DateTime.Now - (DateTime)item.LastPingDate).TotalMinutes;
                            if (minFromLastPing >= item.TIMER)
                                send = true;
                        }

                        if (send)
                        {
                            bool active = PingUrl(item.URL_LINK);
                            item.LastPingDate = DateTime.Now;

                            if (item.OldSituation != null && (bool)item.OldSituation && active == false)
                                MailOperations.SendMail("", "URL Kapandı", item.URL_LINK + " - Erişim Kesildi");

                            item.OldSituation = active;
                            await _hubContext.Clients.Group("Room" + item.USER_ID).SendAsync("PingResult", item.URL_LINK, active, item.ID);
                        }

                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }

        }


        private bool PingUrl(string url)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send(url);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (Exception exp)
            {

                LOGS log = LOGS.GetInstance();
                log.URL = "/PingService/PingUrl";
                log.LEVEL = "Ping Url Error";
                log.MESSAGE = exp.Message;
                log.CREATED_DATE = DateTime.Now;
                _iLogsService.AddAsync(log);

                return false;
            }
        }
    }
}
