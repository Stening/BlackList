namespace BlackList.Migrations

{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlackList.Models.BlackListRepository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //ContextKey = "BlackList.Models.ApplicationDbContext";
        }

        protected override void Seed(BlackList.Models.BlackListRepository context)
        {
            User Dummy = new User { IsMailVerified = false, PhoneNumber = 123, UserName = "dummy", DateCreated = DateTime.Now, Mail = "test@testmail.com" };
            User Dummy2 = new User { IsMailVerified = false, PhoneNumber = 123, UserName = "dummy2", DateCreated = DateTime.Now, Mail = "test2@testmail.com" };

            context.Users.AddOrUpdate(
                Dummy,
                Dummy2

                );

            context.Friends.AddOrUpdate(
                f => f.FriendID,
                new Models.Friend { user = Dummy, friend = Dummy2 });










            //Wcontext.Contacts.AddOrUpdate(p => p.Name,
            //   new Contact
            //   {
            //       Name = "Debra Garcia",
            //       Address = "1234 Main St",
            //       City = "Redmond",
            //       State = "WA",
            //       Zip = "10999",
            //       Email = "debra@example.com",
            //   },
            //    new Contact
            //    {
            //        Name = "Thorsten Weinrich",
            //        Address = "5678 1st Ave W",
            //        City = "Redmond",
            //        State = "WA",
            //        Zip = "10999",
            //        Email = "thorsten@example.com",
            //    },
            //    new Contact
            //    {
            //        Name = "Yuhong Li",
            //        Address = "9012 State st",
            //        City = "Redmond",
            //        State = "WA",
            //        Zip = "10999",
            //        Email = "yuhong@example.com",
            //    },
            //    new Contact
            //    {
            //        Name = "Jon Orton",
            //        Address = "3456 Maple St",
            //        City = "Redmond",
            //        State = "WA",
            //        Zip = "10999",
            //        Email = "jon@example.com",
            //    },
            //    new Contact
            //    {
            //        Name = "Diliana Alexieva-Bosseva",
            //        Address = "7890 2nd Ave E",
            //        City = "Redmond",
            //        State = "WA",
            //        Zip = "10999",
            //        Email = "diliana@example.com",
            //    }
            //    );
            base.Seed(context);



            ////  This method will be called after migrating to the latest version.

            ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            ////  to avoid creating duplicate seed data. E.g.
            ////
            ////    context.People.AddOrUpdate(
            ////      p => p.FullName,
            ////      new Person { FullName = "Andrew Peters" },
            ////      new Person { FullName = "Brice Lambson" },
            ////      new Person { FullName = "Rowan Miller" }
            ////    );
            ////


        }
    }
}
