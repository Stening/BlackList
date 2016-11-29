using System.Linq;
using System.Web.Mvc;

namespace BlackList
{
    [Authorize]
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }
    }
}