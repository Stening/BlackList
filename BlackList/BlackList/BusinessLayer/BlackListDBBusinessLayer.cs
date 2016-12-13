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

        public IQueryable<ApplicationUser> getAllFriends(int userId)
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
                                where auth.user.Email == mail
                                && auth.ListID == listId
                                select auth;

            return authorization.First().Authority;
            
        }


        public IEnumerable<ApplicationUser> getAllUsers()
        {
            //var users = from user
            //            in _context.ListUsers
            //            select user;

            //return users.ToArray();
            throw new NotImplementedException();
        }

        public ApplicationUser getUser(string Email) => _context.Users.Where(u => u.Email == Email).Single();


        public ApplicationUser getFriendTest(string mail)
        {
            var user = getUser(mail);


            var friends = from friend in _context.Friends
                          where friend.UserID == user.Email
                          select friend.friend;

            return friends.FirstOrDefault();
        }



        public ApplicationUser[] GetFriends(string mail)
        {

            var friends = from user in _context.Friends
                          where user.user.Email == mail
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

            var list = _context.ShoppingLists.Where(l => l.ListID == listID).Single();
            var listRelation = from rel in _context.UserMtoMLists
                               where rel.ListID == listID
                               && rel.user.UserName == UserName
                               && rel.Authority == 1
                               select rel;

            var singleRelation = listRelation.First();

            _context.UserMtoMLists.Add(new UserMtoMList
        {
                Authority = 4,
                List = singleRelation.List,
                ListID = singleRelation.ListID,
                user = singleRelation.user,
                UserID = singleRelation.UserID
            });

            _context.SaveChanges();


        }
        //public List<int> getListID(string listId)
        //{
        //    var ListID = from List
        //                  in _context.

        //                 where List.Title == listId
        //                 select List.;

        //    return ListID.ToList();
        //}


        public IEnumerable<CheckList> getMyLists(string Mail)
        {
            var lists = from list in _context.UserMtoMLists
                        //where list.user.Email == Mail
                        select list.List;
            return lists;

        }
        public IEnumerable<ListItem> getListItems(int listID)
        {
            var items = from item in _context.ListItems
                        where item.ListID == listID
                        select item;
            return items;
        }


    }
}