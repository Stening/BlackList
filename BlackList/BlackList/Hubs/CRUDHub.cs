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

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        public void CreateListCode(string listName)
        {

            List NewList = new List();
            NewList.Title = listName;
            NewList.DateCreated = DateTime.Now;
            _context.ShoppingLists.Add(NewList);
            _context.SaveChanges();



            //_context.ShoppingLists.Add(new List
            //{
            //    Title = listName,
            //    DateCreated = DateTime.Now

            //});

            //_context.UserMtoMLists.Add(new UserMtoMList
            //{
            //    ShoppingListID = NewList.ShoppingListID,
            //    UserID = Context.User.Identity.Name

            //});
            //_context.SaveChanges();

            int _listID = NewList.ShoppingListID;

            Clients.All.createList(_listID);
        }

        //Adds words to the list
        public void AddToListCode(string wordForList, int IDFromList)
        {

            ListItem listItem = new ListItem();
            listItem.ItemName = wordForList;
            listItem.ListID = IDFromList;
            _context.ListItems.Add(listItem);
            _context.SaveChanges();

            int listItemID = listItem.ListItemID;



            Clients.All.addToList(wordForList, listItemID);

        }

        //removes word from kist
        public void RemoveFromListCode(int IDFromList)
        {

            var _listID = _context.ListItems.SingleOrDefault(m => m.ListItemID == IDFromList);
            _context.ListItems.Remove(_listID);
            _context.SaveChanges();

            Clients.All.deleteWordfromList(IDFromList);

        }

        public void EditWordListCode(int IDFromListItem, string wordFromList, int IDfromList)
        {
            
            ListItem updateListItem = new ListItem();
            updateListItem.ListItemID = IDFromListItem;
            updateListItem.ItemName = wordFromList;
            updateListItem.ListID = IDfromList;
            _context.Entry(updateListItem).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            //Clients.All.addToList(wordFromList, IDFromListItem);
           

        }


    }
}