using BlackList.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using UserName.Extensions;
using BlackList.Hubs;
using BlackList.BusinessLayer;


namespace BlackList.Hubs
{
    public partial class BlackListHub : Hub
    {
        //private BlackListDbBusinessLayer dbLayer = new BlackListDbBusinessLayer();
        private readonly ApplicationDbContext adb = new ApplicationDbContext();
        // Authorize the method, user logged in will only be able to use this feature.
        // The method will be called from the ChatAll.js file, containing 3 string variables.
        [Authorize]
        public void Send(string message, int listID)
        {
            // Creating a string variable and storing the users Name from the database.
            string name = Context.User.Identity.GetName();

            // Creating a string variable and storing the users email from the database.
            string email = Context.User.Identity.GetUserName();
            
            // Creating a datetime variable and storing the date & time in it.
            DateTime date = DateTime.Now;

            // Creating an instance of the Message object, using it's variables to gather data from database
            Message msg = new Message();
            msg.TimeStamp = date;
            msg.SenderUserID = Context.User.Identity.GetUserId();
            msg.ChatRoomID = adb.ChatRooms.Where(p => p.ListID == listID).First().ChatRoomID;
            msg.ChatMessage = message;

            // Add data to the table.
            adb.Messages.Add(msg);
            // Save the changes.
            adb.SaveChanges();

            var ActiveChatRoomUsers = GetRoomUsers(msg.ChatRoomID);


            // Sends this method back to the function in ChatAll.js that creates <li>name : message</li>.
            // For each message sent.
            // Name is the name the string variable get from the database. Name of the user logged in.
            // Message the the message use typed in the textbox in the view.
            Clients.Clients(ActiveChatRoomUsers).broadcastMessage(email, name, message);
            //Clients.All.broadcastMessage(email, name, message);
            
        }
    }
}