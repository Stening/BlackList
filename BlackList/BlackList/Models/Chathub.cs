using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackList.Models
{
    public class ChatHub : Hub
    {
        // Authorize the method, user logged in will only be able to use this feature.
        // The method will be called from the ChatAll.js file, containing 2 string variables.
        //[Authorize]
        public void Send(string name, string message)
        {
            // Sends this method back to the function in ChatAll.js that creates <li>name : message</li>.
            // For each message sent.
            Clients.All.broadcastMessage(name, message);
        }
    }
}