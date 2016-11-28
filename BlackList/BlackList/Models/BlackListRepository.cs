using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;




namespace BlackList.Models
{
    public class BlackListRepository : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<UserMtoMList> UserMtoMLists { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Friend>().HasRequired(i => i.user).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Friend>().HasRequired(i => i.friend).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<ListItem>().HasRequired(i => i.shoppingList).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<UserMtoMList>().HasRequired(i => i.shoppingList).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<UserMtoMList>().HasRequired(i => i.user).WithMany().WillCascadeOnDelete(false);
        }
    }

    


}