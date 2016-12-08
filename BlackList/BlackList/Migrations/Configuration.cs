namespace BlackList.Migrations
{
    using BlackList.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BlackList.BusinessLayer;

    internal sealed class Configuration : DbMigrationsConfiguration<BlackList.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BlackList.Models.ApplicationDbContext";
        }

        protected override void Seed(BlackList.Models.ApplicationDbContext context)
        {
            context.Contacts.AddOrUpdate(p => p.Name,
               new Contact
               {
                   Name = "Debra Garcia",
                   Address = "1234 Main St",
                   City = "Redmond",
                   State = "WA",
                   Zip = "10999",
                   Email = "debra@example.com",
               },
                new Contact
                {
                    Name = "Thorsten Weinrich",
                    Address = "5678 1st Ave W",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "thorsten@example.com",
                },
                new Contact
                {
                    Name = "Yuhong Li",
                    Address = "9012 State st",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "yuhong@example.com",
                },
                new Contact
                {
                    Name = "Jon Orton",
                    Address = "3456 Maple St",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "jon@example.com",
                },
                new Contact
                {
                    Name = "Diliana Alexieva-Bosseva",
                    Address = "7890 2nd Ave E",
                    City = "Redmond",
                    State = "WA",
                    Zip = "10999",
                    Email = "diliana@example.com",
                }
                );

            SeedHelper date = new SeedHelper();

            //List first = new List { ShoppingListID = 1,Title = "First", DateCreated = date.Randomday() };
            //List second = new List { ShoppingListID = 2, Title = "Second", DateCreated = date.Randomday() };
            //List third = new List { ShoppingListID = 3, Title = "Third", DateCreated = date.Randomday() };
            //context.ShoppingLists.AddOrUpdate(n => n.Title, first, second, third);
            //context.SaveChanges();

            //ListItem a1 = new ListItem { ListItemID = 1, ItemName = "A", ListID = first.ShoppingListID };
            //ListItem a2 = new ListItem { ListItemID = 2, ItemName = "A", ListID = second.ShoppingListID };
            //ListItem a3 = new ListItem { ListItemID = 3, ItemName = "A", ListID = third.ShoppingListID };
            //ListItem b1 = new ListItem { ListItemID = 4, ItemName = "B", ListID = first.ShoppingListID };
            //ListItem c1 = new ListItem { ListItemID = 5, ItemName = "C", ListID = first.ShoppingListID };
            //context.ListItems.AddOrUpdate(n => n.ItemName, a1, a2, a3, b1, c1);
            //context.SaveChanges();

            //ListUser link = new ListUser { UserID = 1, UserName = "Linkan", DateCreated = date.Randomday() };
            //ListUser stening = new ListUser { UserID = 2, UserName = "Stening", DateCreated = date.Randomday() };
            //ListUser alex = new ListUser { UserID = 3, UserName = "Alex", DateCreated = date.Randomday() };
            //context.ListUsers.AddOrUpdate(n =>n.UserName, link, stening, alex);
            //context.SaveChanges();

            //UserMtoMList linklist = new UserMtoMList { UserID = link.UserID, ListID = first.ShoppingListID };
            //UserMtoMList linklist2 = new UserMtoMList { UserID = link.UserID, ListID = second.ShoppingListID };
            //UserMtoMList steninglist = new UserMtoMList { UserID = stening.UserID, ListID = third.ShoppingListID };
            //UserMtoMList alexlist = new UserMtoMList { UserID = alex.UserID, ListID = first.ShoppingListID };
            //context.UserMtoMLists.AddOrUpdate(linklist, linklist2, steninglist, alexlist);
            //context.SaveChanges();
        }

    }




}
