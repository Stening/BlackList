﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;




namespace ShoppingList.Models
{
    public class BlackListRepository : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<UserMtoMList> UserMtoMLists { get; set; }

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<aspnet_UsersInRoles>().HasMany(i => i.Users).WithRequired().WillCascadeOnDelete(false);
    }


}