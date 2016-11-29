using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackList.Models;
namespace BlackList.BusinessLayer
{
    public class BlackListDbBusinessLayer
    {
        private readonly BlackListRepository _context;

        public BlackListDbBusinessLayer(BlackListRepository DbContext)
        {
            _context = DbContext;
        }
        public IQueryable<User> getAllFriends(int userId)
        {
            var friends = from friend
                          in _context.Friends
                          join u
                          in _context.Users
                          on friend.FriendID
                          equals u.UserID
                          where friend.FriendID == u.UserID
                          select u;

            return friends;
        }




    }
}