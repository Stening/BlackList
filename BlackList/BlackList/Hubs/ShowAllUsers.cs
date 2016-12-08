using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using BlackList.Models;
using System.Collections;

namespace BlackList.Hubs
{
    public class ShowAllUsers : Hub
    {

        public ApplicationDbContext _context = new ApplicationDbContext();

        public ShowAllUsers()
        {
            _context = new ApplicationDbContext();
        }

        public void Send()
        {
            var allTheUsers = getAllUsers();
            Clients.Caller.updateUserList(allTheUsers);

        }

        // Have to make the method only take the people that are non-friends.
        public IEnumerable getAllUsers()
        {
            var users = from user
                        in _context.Users
                        select user.UserName;

            return users.ToArray();
        }


    }
}
