using BlackList.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using UserName.Extensions;

namespace BlackList
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext adb = new ApplicationDbContext();
        // Authorize the method, user logged in will only be able to use this feature.
        // The method will be called from the ChatAll.js file, containing 3 string variables.
        [Authorize]
        public void Send(string message)
        {
            // Creating a string variable and storing the users Name from the database.
            string name = Context.User.Identity.GetName();

            // Creating a string variable and storing the users email from the database.
            string email = Context.User.Identity.GetUserName();

            // Sends this method back to the function in ChatAll.js that creates <li>name : message</li>.
            // For each message sent.
            // Name is the name the string variable get from the database. Name of the user logged in.
            // Message the the message use typed in the textbox in the view.
            Clients.All.broadcastMessage(email, name, message);
        }
    }
}