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

        public IEnumerable<ApplicationUser> getChatRoomUsers(int roomID)
        {
            var users = from user in _context.ChatRoomUsers
                        where user.ChatRoomID == roomID
                        select user.user;
            return users;
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

            var friends = (from user in _context.Friends
                           where user.user.Email == mail
                           select user.friend).Union
                          (from user in _context.Friends
                           where user.friend.Email == mail
                           select user.user);
                          
            
            friends = friends.Where(f => f.Email != mail);
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

        public CheckList getList(int listID)
        {
            var lists = from list in _context.ShoppingLists
                        where list.ListID == listID
                        select list;
            return lists.First();
        }

        public void InviteToList(int listID,string UserName)
        {
            var existingRels = from rel in _context.UserMtoMLists
                               where rel.user.Email == UserName &&
                               rel.ListID == listID
                               select rel;

            if (existingRels.Count() == 0 )
            {

                var chatrooms = from chatroom in _context.ChatRooms
                                where listID == chatroom.ListID
                                select chatroom;
                ChatRoom chatroomRef = chatrooms.First();
            var lists = from list in _context.ShoppingLists
                        where list.ListID == listID
                        select list;
            CheckList listRef = lists.First();
            //var singleRelation = listRelation.First();
            var users = from user in _context.Users
                        where user.Email == UserName
                        select user;

            ApplicationUser userRef = users.First();
                _context.ChatRoomUsers.Add(new ChatRoomUser
                {
                    user = userRef,
                    UserId = userRef.Id,
                    chatRoom = chatroomRef,
                    ChatRoomID = chatroomRef.ChatRoomID
                });

            _context.UserMtoMLists.Add(new UserMtoMList
            {
                Authority = 4,
                ListID = listRef.ListID,
                List = listRef,
                UserID = userRef.Id,
                user = userRef

            });

            _context.SaveChanges();
            }

        }
        //public List<int> getListID(string listId)
        //{
        //    var ListID = from List
        //                  in _context.

        //                 where List.Title == listId
        //                 select List.;

        //    return ListID.ToList();
        //}

        //    public IEnumerable<ApplicationUser> getUsersInChatRoom(int chatroomID)
        //{
        //    var users = from user in _context.ChatRoomUsers
        //                where user.ChatRoomID == chatroomID
        //                select user.user;

        //    return users;

        //}
        public IEnumerable<CheckList> getMyLists(string Mail)
        {
            var lists = from list in _context.UserMtoMLists
                        where list.user.Email == Mail
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