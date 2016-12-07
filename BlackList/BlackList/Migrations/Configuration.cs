namespace BlackList.Migrations
{
    using BlackList.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlackList.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BlackList.Models.ApplicationDbContext";
        }

        protected override void Seed(Models.ApplicationDbContext context)
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


            ListUser stening = new ListUser
            {
                UserID = 1,
                UserName = "Stening",
                Mail = "stening.johan@gmail.com",
                DateCreated = DateTime.Now
            };
            ListUser wigge = new ListUser
            {
                UserID = 2,
                UserName = "wigge",
                Mail = "wigge@test.com",
                DateCreated = DateTime.Now

            };
            ListUser linkan = new ListUser
            {
                UserID = 3,
                UserName = "linkan",
                Mail = "linkan@test.com",
                DateCreated = DateTime.Now

            };
            ListUser josse = new ListUser
            {
                UserID = 4,
                UserName = "josse",
                Mail = "josse@test.com",
                DateCreated = DateTime.Now
            };


            context.ListUsers.AddOrUpdate(
                n => n.UserName,
               linkan, josse, wigge, stening);

            Friend steninglinkan = new Friend
            {
                user = stening,
                UserID = stening.UserID,
                FriendID = linkan.UserID,
                friend = linkan
                
            };
            Friend steningJosse = new Friend
            {
                UserID = stening.UserID,
                user = stening,
                FriendID = josse.UserID,
                friend = josse
                
        };
            context.Friends.AddOrUpdate(steninglinkan, steningJosse);
        }

    }




    }
