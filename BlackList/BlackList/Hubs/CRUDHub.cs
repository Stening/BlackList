using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using BlackList.Models;

namespace BlackList.Hubs
{
    public class CRUDHub : Hub
    {

        private readonly BlackListRepository _context = new BlackListRepository();

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        public void CreateListCode(string listName)
        {

            _context.ShoppingLists.Add(new ShoppingList
            {
                Title = listName,
                DateCreated = DateTime.Now
                
            });

            _context.SaveChanges();
            Clients.All.createList();
        }

        public void AddToListCode(string wordForList)
        {

            Clients.All.addToList(wordForList, 1);

        }

    }
}