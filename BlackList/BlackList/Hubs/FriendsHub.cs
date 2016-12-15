using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using BlackList.Models;
using System.Threading.Tasks;

namespace BlackList.Hubs
{
    public class FriendsHub : Hub
    {
        static BlackList.BusinessLayer.BlackListDbBusinessLayer dbLayer = new BusinessLayer.BlackListDbBusinessLayer();
        public static Dictionary<string, ConnectedUser> connectedUsers = new Dictionary<string, ConnectedUser>();

        public void ConnectToFriends()
        {
            var myName = Context.User.Identity.Name;
            //var y = dbLayer.getFriendTest(myName);
            //var me = dbLayer.getUserBymail(myName);

            var friends = dbLayer.GetFriends(myName);


            //Dummy Code
            //if (!connectedUsers.ContainsKey(friends[0].Email))
            //{
            //    connectedUsers.Add(friends[0].Email, new ConnectedUser(friends[0].Email, null, true, "12345"));
            //}
            //if (!connectedUsers.ContainsKey(friends[1].Email))
            //{
            //    connectedUsers.Add(friends[1].Email, new ConnectedUser(friends[1].Email, null, true, "12345"));
            //}
            //Dummy code




            if (!connectedUsers.ContainsKey(myName))
            {
                connectedUsers.Add(myName, new ConnectedUser(myName, friends, true, Context.ConnectionId));
            }
            else
            {
                connectedUsers[myName].Friends = friends;
            }

            //Clients.All.renderFriends(friends);
            //List<string> FriendIds = new List<string>();
            string[] FriendIds = new string[friends.Length];
            for (int i = 0; i < friends.Length; i++)
            {
                ConnectedUser temp;
                if (connectedUsers.TryGetValue(friends[i].Email, out temp))
                {

                    FriendIds[i] = temp.ConnectionId;
                }
            }


            //FriendIds[FriendIds.Length - 1] = Context.ConnectionId;
            Clients.Clients(FriendIds).updateFriends();
            UpdateConnectedFriends();
        }
        public override Task OnConnected()
        {
            ConnectToFriends();
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            DisconnectFromFriends();

            return base.OnDisconnected(stopCalled);
        }



        public void DisconnectFromFriends()
        {
            var myName = Context.User.Identity.Name;

            ConnectedUser me = connectedUsers[myName];
            string[] friendIds = new string[me.Friends.Length];
            for (int i = 0; i < me.Friends.Length; i++)
            {
                ConnectedUser temp;
                if (connectedUsers.TryGetValue(me.Friends[i].Email, out temp))
                {
                    friendIds[i] = temp.ConnectionId;
                }
            }
            connectedUsers.Remove(myName);
            Clients.Clients(friendIds).updateFriends();
        }


        public void InviteToList(string userNameToInvite, int listId)
        {
            dbLayer.InviteToList(listId, userNameToInvite);
            ConnectedUser temp;
            if (connectedUsers.TryGetValue(userNameToInvite, out temp))
            {
                Clients.Client(temp.ConnectionId).renderMyLists();
            }

            //call client method to update lists here!

        }



        public void UpdateConnectedFriends()
        {
            string myName = Context.User.Identity.Name;
            ApplicationUser[] MyFriends = connectedUsers[myName].Friends;

            ConnectedUser[] FriendStatuses = new ConnectedUser[MyFriends.Length];

            for (int i = 0; i < MyFriends.Length; i++)
            {
                ConnectedUser temp;
                if (connectedUsers.TryGetValue(MyFriends[i].Email, out temp))
                {
                    FriendStatuses[i] =
                    new ConnectedUser(MyFriends[i].Email, null, true, temp.ConnectionId);
                }
                else
                {
                    FriendStatuses[i] =
                    new ConnectedUser(MyFriends[i].Email, null, false, "");
                }

            }

            Clients.Caller.renderFriends(FriendStatuses);

        }






        public void sendToRoom(int chatRoomID, string message)
        {
            // save the message in DB also!
            string[] connectionIDs = GetRoomUsers(chatRoomID);

            Clients.Clients(connectionIDs).receiveMessage(chatRoomID);

        }




        public string[] GetRoomUsers(int chatRoomID)
        {
            ApplicationUser[] users = dbLayer.getChatRoomUsers(chatRoomID).ToArray();
            string[] connectionIds = new string[users.Length];
            //ConnectedUser[] connectedUsersFiltered = new ConnectedUser[users.Length];
            for (int i = 0; i < users.Length; i++)
            {
                ConnectedUser temp;
                if (connectedUsers.TryGetValue(users[i].Email, out temp))
                {
                    connectionIds[i] = temp.ConnectionId;
                    //connectedUsersFiltered[i] = temp;
                }
            }
            return connectionIds;
            //return connectedUsersFiltered;
        }




        public class ConnectedUser
        {
            public ConnectedUser(string userName, ApplicationUser[] friends, bool isOnline, string connectionId)
            {
                UserName = userName;
                Online = isOnline;
                ConnectionId = connectionId;
                Friends = friends;
            }
            public string UserName { get; set; }
            public bool Online { get; set; }
            public string ConnectionId { get; set; }
            public ApplicationUser[] Friends { get; set; }

        }
    }
}