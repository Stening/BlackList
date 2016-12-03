using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlackList.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Hometown { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BlackListDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BlackList.Models.Contact> Contacts { get; set; }

        public DbSet<ListUser> ListUsers { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<List> ShoppingLists { get; set; }
        public DbSet<ListItem> ListItems { get; set; }
        public DbSet<UserMtoMList> UserMtoMLists { get; set; }
        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ChatRoomUser> ChatRoomUsers { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Friend>().HasRequired(i => i.user).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Friend>().HasRequired(i => i.friend).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<ListItem>().HasRequired(i => i.shoppingList).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<UserMtoMList>().HasRequired(i => i.shoppingList).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<UserMtoMList>().HasRequired(i => i.user).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<ChatRoomUser>().HasRequired(i => i.user).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<ChatRoomUser>().HasRequired(i => i.chatRoom).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<ChatRoom>().HasRequired(i => i.shoppingList).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Message>().HasRequired(i => i.chatRoom).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Message>().HasRequired(i => i.PreviousMessage).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Message>().HasRequired(i => i.Sender).WithMany().WillCascadeOnDelete(false);



        }






    }
}