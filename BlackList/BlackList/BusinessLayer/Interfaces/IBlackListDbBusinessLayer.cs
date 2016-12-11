using BlackList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackList.BusinessLayer.Interfaces
{
    public interface IBlackListDbBusinessLayer
    {
        IQueryable<ApplicationUser> getAllFriends(int userId);

        int GetAuthorizationRole(string mail, int listId);
       
        IEnumerable<ApplicationUser> getAllUsers();

        ApplicationUser getUser(string Email);


        ApplicationUser getFriendTest(string mail);

        ApplicationUser[] GetFriends(string mail);

        void InviteToList(int listID, string UserName);




    }
}
