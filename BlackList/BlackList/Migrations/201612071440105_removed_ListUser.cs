namespace BlackList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_ListUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChatRooms", "ShoppingListID", "dbo.Lists");
            DropForeignKey("dbo.ListItems", "ListID", "dbo.Lists");
            DropForeignKey("dbo.UserMtoMLists", "ShoppingListID", "dbo.Lists");
            DropIndex("dbo.ChatRooms", new[] { "ShoppingListID" });
            DropIndex("dbo.ChatRoomUsers", new[] { "UserID" });
            DropIndex("dbo.Friends", new[] { "UserID" });
            DropIndex("dbo.Friends", new[] { "FriendID" });
            DropIndex("dbo.Messages", new[] { "SenderUserID" });
            DropIndex("dbo.UserMtoMLists", new[] { "UserID" });
            DropIndex("dbo.UserMtoMLists", new[] { "ShoppingListID" });
            DropPrimaryKey("dbo.ChatRoomUsers");
            DropPrimaryKey("dbo.Friends");
            DropPrimaryKey("dbo.UserMtoMLists");
            CreateTable(
                "dbo.CheckLists",
                c => new
                    {
                        ListID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ListID);
            
            AddColumn("dbo.ChatRooms", "ListID", c => c.Int(nullable: false));
            AddColumn("dbo.UserMtoMLists", "ListID", c => c.Int(nullable: false));
            AlterColumn("dbo.ChatRoomUsers", "UserID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Friends", "UserID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Friends", "FriendID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Messages", "SenderUserID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.UserMtoMLists", "UserID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ChatRoomUsers", new[] { "ChatRoomID", "UserID" });
            AddPrimaryKey("dbo.Friends", new[] { "UserID", "FriendID" });
            AddPrimaryKey("dbo.UserMtoMLists", new[] { "UserID", "ListID" });
            CreateIndex("dbo.ChatRooms", "ListID");
            CreateIndex("dbo.ChatRoomUsers", "UserID");
            CreateIndex("dbo.Friends", "UserID");
            CreateIndex("dbo.Friends", "FriendID");
            CreateIndex("dbo.Messages", "SenderUserID");
            CreateIndex("dbo.UserMtoMLists", "UserID");
            CreateIndex("dbo.UserMtoMLists", "ListID");
            AddForeignKey("dbo.ChatRooms", "ListID", "dbo.CheckLists", "ListID");
            AddForeignKey("dbo.ListItems", "ListID", "dbo.CheckLists", "ListID");
            AddForeignKey("dbo.UserMtoMLists", "ListID", "dbo.CheckLists", "ListID");
            DropColumn("dbo.ChatRooms", "ShoppingListID");
            DropColumn("dbo.UserMtoMLists", "ShoppingListID");
            DropTable("dbo.Lists");
            DropTable("dbo.ListUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ListUsers",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Mail = c.String(),
                        IsMailVerified = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ShoppingListID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingListID);
            
            AddColumn("dbo.UserMtoMLists", "ShoppingListID", c => c.Int(nullable: false));
            AddColumn("dbo.ChatRooms", "ShoppingListID", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserMtoMLists", "ListID", "dbo.CheckLists");
            DropForeignKey("dbo.ListItems", "ListID", "dbo.CheckLists");
            DropForeignKey("dbo.ChatRooms", "ListID", "dbo.CheckLists");
            DropIndex("dbo.UserMtoMLists", new[] { "ListID" });
            DropIndex("dbo.UserMtoMLists", new[] { "UserID" });
            DropIndex("dbo.Messages", new[] { "SenderUserID" });
            DropIndex("dbo.Friends", new[] { "FriendID" });
            DropIndex("dbo.Friends", new[] { "UserID" });
            DropIndex("dbo.ChatRoomUsers", new[] { "UserID" });
            DropIndex("dbo.ChatRooms", new[] { "ListID" });
            DropPrimaryKey("dbo.UserMtoMLists");
            DropPrimaryKey("dbo.Friends");
            DropPrimaryKey("dbo.ChatRoomUsers");
            AlterColumn("dbo.UserMtoMLists", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "SenderUserID", c => c.Int(nullable: false));
            AlterColumn("dbo.Friends", "FriendID", c => c.Int(nullable: false));
            AlterColumn("dbo.Friends", "UserID", c => c.Int(nullable: false));
            AlterColumn("dbo.ChatRoomUsers", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.UserMtoMLists", "ListID");
            DropColumn("dbo.ChatRooms", "ListID");
            DropTable("dbo.CheckLists");
            AddPrimaryKey("dbo.UserMtoMLists", new[] { "UserID", "ShoppingListID" });
            AddPrimaryKey("dbo.Friends", new[] { "UserID", "FriendID" });
            AddPrimaryKey("dbo.ChatRoomUsers", new[] { "ChatRoomID", "UserID" });
            CreateIndex("dbo.UserMtoMLists", "ShoppingListID");
            CreateIndex("dbo.UserMtoMLists", "UserID");
            CreateIndex("dbo.Messages", "SenderUserID");
            CreateIndex("dbo.Friends", "FriendID");
            CreateIndex("dbo.Friends", "UserID");
            CreateIndex("dbo.ChatRoomUsers", "UserID");
            CreateIndex("dbo.ChatRooms", "ShoppingListID");
            AddForeignKey("dbo.UserMtoMLists", "ShoppingListID", "dbo.Lists", "ShoppingListID");
            AddForeignKey("dbo.ListItems", "ListID", "dbo.Lists", "ShoppingListID");
            AddForeignKey("dbo.ChatRooms", "ShoppingListID", "dbo.Lists", "ShoppingListID");
        }
    }
}
