using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using BlackList.Models;
using BlackList.BusinessLayer;
using Microsoft.AspNet.Identity;

namespace BlackList.Hubs
{
    public class CRUDHub : Hub
    {

        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private static BlackListDbBusinessLayer dbLayer = new BlackListDbBusinessLayer();
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        public void CreateListCode(string listName)
        {

            CheckList NewList = new CheckList();
            NewList.Title = listName;
            NewList.DateCreated = DateTime.Now;
            _context.ShoppingLists.Add(NewList);
            _context.SaveChanges();

            CheckList bl = new CheckList();
            var f = bl.ListID;
            //int val = f[0];

            //_context.ShoppingLists.Add(new List
            //{
            //    Title = listName,
            //    DateCreated = DateTime.Now

            //});

            //_context.UserMtoMLists.Add(new UserMtoMList
            //{
            //    ShoppingListID = NewList.ShoppingListID,
            var UserID = Context.User.Identity.Name;

            // UserID
            //});
            //_context.SaveChanges();
            string userMail = Context.User.Identity.Name;

            var id = HttpContext.Current.User.Identity.GetUserId();


            int _listID = NewList.ListID;



            string query = "INSERT INTO UserMtoMLists(UserID,ListID,Authority) VALUES ('" + id + "', '" + _listID + "', '" + 1 + "')";
            _context.Database.ExecuteSqlCommand(query);
            _context.SaveChanges();


            Clients.All.createList(_listID);



            //string query = "INSERT INTO UserMtoMLists(UserID,ShoppingListID,Authority) VALUES ('" + id + "', '" + val + "', '" + 1 + "')";


            //_context.Database.ExecuteSqlCommand(query);
            //_context.SaveChanges();


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

            ListItem updateListItem = new ListItem();
            updateListItem.ListItemID = IDFromListItem;
            updateListItem.ItemName = wordFromList;
            updateListItem.ListID = IDfromList;
            _context.Entry(updateListItem).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();

            //Clients.All.addToList(wordFromList, IDFromListItem);


        }

        public void GetMyLists()
        {
            var myMail = Context.User.Identity.Name;

            var myLists = dbLayer.getMyLists(myMail);

            Clients.Caller.RenderMyLists(myLists.ToArray());

        }

        public void GetListItems(int listID)
        {
            var myMail = Context.User.Identity.Name;

            var myLists = dbLayer.getMyLists(myMail);

            Clients.Caller.renderMyLists(myLists.ToArray());

        }

    }
}