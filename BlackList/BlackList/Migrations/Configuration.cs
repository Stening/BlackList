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
            
            
            CheckList first = new CheckList { ListID = 1,Title = "First", DateCreated = date.Randomday() };
            CheckList second = new CheckList { ListID = 2, Title = "Second", DateCreated = date.Randomday() };
            CheckList third = new CheckList { ListID = 3, Title = "Third", DateCreated = date.Randomday() };
            context.ShoppingLists.AddOrUpdate(n => n.Title, first, second, third);
            context.SaveChanges();

            ListItem a1 = new ListItem { ListItemID = 1, ItemName = "A", ListID = first.ListID };
            ListItem a2 = new ListItem { ListItemID = 2, ItemName = "B", ListID = second.ListID };
            ListItem a3 = new ListItem { ListItemID = 3, ItemName = "C", ListID = third.ListID };
            ListItem b1 = new ListItem { ListItemID = 4, ItemName = "D", ListID = first.ListID };
            ListItem c1 = new ListItem { ListItemID = 5, ItemName = "E", ListID = first.ListID };
            context.ListItems.AddOrUpdate(n => n.ItemName, a1, a2, a3, b1, c1);
            context.SaveChanges();


            ApplicationUser link = new ApplicationUser { Id = "1", UserName = "Linkan", Email = "Link@test.com" };
            ApplicationUser stening = new ApplicationUser { Id = "2", UserName = "Stening"};
            ApplicationUser alex = new ApplicationUser { Id = "3", UserName = "Alex",Email ="Alex@test.com"};
            context.Users.AddOrUpdate(n =>n.UserName, link, stening, alex);
            context.SaveChanges();

            Friend linkStening = new Friend
            {
                friend = link,
                FriendID = link.Id,
                UserID = "a4b316ae-b1eb-4ed4-ab0a-689a68b1956b" //this will need to change when switching PC
            };
            Friend AlexStening = new Friend
            {
                friend = alex,
                FriendID = alex.Id,
                UserID = "a4b316ae-b1eb-4ed4-ab0a-689a68b1956b" //this will need to change when switching PC
            };
            context.Friends.AddOrUpdate(n =>new {n.UserID, n.FriendID }, AlexStening, linkStening);
            context.SaveChanges();
            UserMtoMList linklist = new UserMtoMList { UserID = link.Id, ListID = first.ListID };
            UserMtoMList linklist2 = new UserMtoMList { UserID = link.Id, ListID = second.ListID };
            UserMtoMList steninglist = new UserMtoMList { UserID = stening.Id, ListID = third.ListID };
            UserMtoMList alexlist = new UserMtoMList { UserID = alex.Id, ListID = first.ListID };
            context.UserMtoMLists.AddOrUpdate(i => new {i.UserID, i.ListID }, linklist, linklist2, steninglist, alexlist);
            context.SaveChanges();
        }
    }
}
