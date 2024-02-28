using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLhealth.Web.UI.MyHubs
{
    public class UrlHubs:Hub
    {
        private static int clientCount { get; set; } = 0;
        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", new { clientCount = clientCount });
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", new { clientCount = clientCount});
        }


        public async Task JoinRoom(string name)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, name);
        }

        public async Task SendPingResult(string rName, string url, bool active, int id)
        {
            await Clients.Group("Room" + "1").SendAsync("PingResult", url, active, id);
        }

    }
}
