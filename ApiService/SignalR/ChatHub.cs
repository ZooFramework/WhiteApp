using Microsoft.AspNetCore.SignalR;
using ZooFramework.ApiService.Attributes;

namespace ZooFramework.WhiteApp.ApiService.SignalR
{
    [SignalRHubUrl("/chatHub")]
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.SendAsync("broadcastMessage", name, message);
        }
    }
}