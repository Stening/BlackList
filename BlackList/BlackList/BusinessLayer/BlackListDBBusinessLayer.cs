using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackList.Models;
namespace BlackList.BusinessLayer
{
    public class BlackListDbBusinessLayer
    {
        private readonly ApplicationDbContext _context;

        public BlackListDbBusinessLayer()
        {
            _context = new ApplicationDbContext();
        }

        public IQueryable<ListUser> getAllFriends(int userId)
        {
            var friends = from friend
                          in _context.Friends
                          join u
                          in _context.ListUsers
                          on friend.FriendID
                          equals u.UserID
                          where friend.FriendID == u.UserID
                          select u;

            return friends;
        }
        public IEnumerable<ListUser> getAllUsers()
        {
            var users = from user
                        in _context.ListUsers
                        select user;

            return users.ToArray();
        }



    }
}