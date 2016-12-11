using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackList.Models.Interfaces
{
    public interface IApplicationDbContext
    {






        System.Data.Entity.DbSet<BlackList.Models.Contact> Contacts { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }
        DbSet<Friend> Friends { get; set; }
        DbSet<CheckList> ShoppingLists { get; set; }
        DbSet<ListItem> ListItems { get; set; }
        DbSet<UserMtoMList> UserMtoMLists { get; set; }
        DbSet<ChatRoom> ChatRooms { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<ChatRoomUser> ChatRoomUsers { get; set; }

        void SaveChanges();
    }
}
