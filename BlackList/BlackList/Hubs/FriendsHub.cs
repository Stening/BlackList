using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace BlackList.Hubs
{
    public class FriendsHub : Hub
    {
        static BlackList.BusinessLayer.BlackListDbBusinessLayer dbLayer = new BusinessLayer.BlackListDbBusinessLayer();
        public void GetFriends(string userName)
        {

            var x = dbLayer.GetFriends(userName);



        }
        
    }
}