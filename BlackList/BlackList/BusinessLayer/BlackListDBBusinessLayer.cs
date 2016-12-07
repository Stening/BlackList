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
            // needs re-writing
            //var friends = from friend
            //              in _context.Friends
            //              join u
            //              in _context.Users
            //              on friend.FriendID
            //              equals u.
            //              where friend.FriendID == u.UserID
            //              select u;

            //return friends;
            throw new NotImplementedException();
        }

        public int GetAuthorizationRole(string mail, int listId)
        {

            var authorization = from auth in _context.UserMtoMLists
                                where auth.user.Mail == mail
                                && auth.ShoppingListID == listId
                                select auth;

            return authorization.First().Authority;
            
        }

        public IEnumerable<ListUser> getAllUsers()
        {
            //var users = from user
            //            in _context.ListUsers
            //            select user;

            //return users.ToArray();
            throw new NotImplementedException();
        }

        public ListUser getUser(string userName) => _context.ListUsers.Where(u => u.UserName == userName).Single();
        public ListUser getUserBymail(string email) => _context.ListUsers.Where(u => u.Mail == email).Single();

        public ListUser getFriendTest(string mail)
        {
            var user = getUserBymail(mail);


            var friends = from friend in _context.Friends
                          where friend.UserID == user.UserID
                          select friend.friend;

            return friends.FirstOrDefault();
        }



        public ListUser[] GetFriends(string mail)
        {

            var friends = from user in _context.Friends
                          where user.user.Mail == mail
                          select user.friend;
            

            //var friends = from user in _context.ListUsers
            //              where user.
            //              from buddy in _context.Friends
            //              where user.UserID == buddy.UserID
            //              from userfriend in _context.ListUsers
            //              where userfriend.UserID == buddy.FriendID
            //              select userfriend;
            // group buddy by buddy.friend into grp
            //select grp.Key;


                          //var test = from friend in _context.ListUsers
                          //           where friend.UserName 
                          //           select friend;


            return friends.ToArray();
        }


        public void InviteToList(int listID,string UserName)
        {

            var list = _context.ShoppingLists.Where(l => l.ShoppingListID == listID).Single();
            var listRelation = from rel in _context.UserMtoMLists
                               where rel.ShoppingListID == listID
                               && rel.user.UserName == UserName
                               && rel.Authority == 1
                               select rel;

            var singleRelation = listRelation.First();

            _context.UserMtoMLists.Add(new UserMtoMList
            {
                Authority = 4,
                shoppingList = singleRelation.shoppingList,
                ShoppingListID = singleRelation.ShoppingListID,
                user = singleRelation.user,
                UserID = singleRelation.UserID
            });

            _context.SaveChanges();


        }





    }
}