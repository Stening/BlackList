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

            Models.CheckList NewList = new Models.CheckList();
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

            int _listID = NewList.ListID;

            Clients.All.createList(_listID);
        }

        /// <summary>
        /// Reading of the List function
        /// </summary>
        /// <param name="listTitle"></param>
        /// <param name="IDFromList"></param>
        public void readTheList(string listTitle, int listID)
        {
            CheckList checklist = new CheckList();

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
            //var _listID = _context.ListItems.SingleOrDefault(m => m.ListItemID == IDFromList);
            ListItem updateListItem = new ListItem();
            updateListItem.ListItemID = IDFromListItem;
            updateListItem.ItemName = wordFromList;
            updateListItem.ListID = IDfromList;
            _context.Entry(updateListItem).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            Clients.All.addToList(wordFromList, IDFromListItem );
            //Clients.All.updateWordfromList(IDFromList);

        }


    }
}