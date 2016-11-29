using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using static ShoppingList.UserContext;

namespace ShoppingList
{
    //[Authorize]
    public class ChatHub : Hub
    {
        //public void Send(string name, string message)
        //{
        //    // Call the broadcastMessage method to update clients.
        //    Clients.All.broadcastMessage(name, message);
        //    Clients.Group("RoomA").addMessage("Group Message " + message);
        //}

        public void Send(string name, string group, string message)
        {
            Clients.All.broadcastMessage(name, group, message);

            //Clients.Group(message).broadcastMessage(name, message);
            //Clients.All.addMessage(name, message.Msg);
            //Clients.Group(message.Group).addMessage("Group Message " + name + message.Msg);
        }
        public void JoinRoom(string groupName)
        {
            Groups.Add(Context.ConnectionId, groupName);
        }

        //public Task LeaveRoom(string roomName)
        //{
        //    return Groups.Remove(Context.ConnectionId, roomName);
        //}

        //public override Task OnConnected()
        //{
        //    using (var db = new UserContext())
        //    {
        //        // Retrieve user.
        //        var user = db.Users
        //            .Include(u => u.Rooms)
        //            .SingleOrDefault(u => u.UserName == Context.User.Identity.Name);

        //        // If user does not exist in database, must add.
        //        if (user == null)
        //        {
        //            user = new User()
        //            {
        //                UserName = Context.User.Identity.Name
        //            };
        //            db.Users.Add(user);
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            // Add to each assigned group.
        //            foreach (var item in user.Rooms)
        //            {
        //                Groups.Add(Context.ConnectionId, item.RoomName);
        //            }
        //        }
        //    }
        //    return base.OnConnected();
        //}

        //public void AddToRoom(string roomName)
        //{
        //    using (var db = new UserContext())
        //    {
        //        // Retrieve room.
        //        var room = db.Rooms.Find(roomName);

        //        if (room != null)
        //        {
        //            var user = new User() { UserName = Context.User.Identity.Name };
        //            db.Users.Attach(user);

        //            room.Users.Add(user);
        //            db.SaveChanges();
        //            Groups.Add(Context.ConnectionId, roomName);
        //        }
        //    }
        //}

        //public void RemoveFromRoom(string roomName)
        //{
        //    using (var db = new UserContext())
        //    {
        //        // Retrieve room.
        //        var room = db.Rooms.Find(roomName);
        //        if (room != null)
        //        {
        //            var user = new User() { UserName = Context.User.Identity.Name };
        //            db.Users.Attach(user);

        //            room.Users.Remove(user);
        //            db.SaveChanges();

        //            Groups.Remove(Context.ConnectionId, roomName);
        //        }
        //    }
        //}






        //Clients.Group(groupName).addChatMessage(name, message);
        //Clients.Group(groupName, connectionId1, connectionId2).addChatMessage(name, message);
        //Clients.OthersInGroup(groupName).addChatMessage(name, message);



        //If you want to add client to group immediatly
        //public async Task JoinRoom(string roomName)
        //{
        //    await Groups.Add(Context.ConnectionId, roomName);
        //    Clients.Group(roomName).addChatMessage(Context.User.Identity.Name + " joined.");
        //}
    }
}