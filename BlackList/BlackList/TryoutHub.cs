using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using BlackList;
using System.Threading.Tasks;

namespace BlackList
{
    public static class UserHandler
    {
        public static Dictionary<string, ConnectedUser> ConnectedUsers = new Dictionary<string, ConnectedUser>();
    }


    public class TryOutHub : Hub
    {
        //private Models.BlackListRepository _context;

        //public void Test(string id)
        //{
        //    BlackList.BusinessLayer.BlackListDbBusinessLayer handler = new BusinessLayer.BlackListDbBusinessLayer();
        //    int intId = int.Parse(id);
        //    //var x = handler.getAllFriends(intId).ToList();
        //    var x = handler.getAllUsers().ToList();

        //    Clients.All.testMethod(x[intId].UserName);



        //}









        public override Task OnConnected()
        {

            // get friends from db and insert to ConnectedUser class
            //UserHandler.ConnectedUsers.Add(Context.ConnectionId, );


            return base.OnConnected();
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }
    }
}