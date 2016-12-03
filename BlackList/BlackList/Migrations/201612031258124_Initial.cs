namespace BlackList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatRooms",
                c => new
                    {
                        ChatRoomID = c.Int(nullable: false, identity: true),
                        ShoppingListID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChatRoomID)
                .ForeignKey("dbo.Lists", t => t.ShoppingListID)
                .Index(t => t.ShoppingListID);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ShoppingListID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingListID);
            
            CreateTable(
                "dbo.ChatRoomUsers",
                c => new
                    {
                        ChatRoomID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ChatRoomID, t.UserID })
                .ForeignKey("dbo.ChatRooms", t => t.ChatRoomID)
                .ForeignKey("dbo.ListUsers", t => t.UserID)
                .Index(t => t.ChatRoomID)
                .Index(t => t.UserID);
            
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
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        FriendID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.FriendID })
                .ForeignKey("dbo.ListUsers", t => t.FriendID)
                .ForeignKey("dbo.ListUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.FriendID);
            
            CreateTable(
                "dbo.ListItems",
                c => new
                    {
                        ListItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        ListID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListItemID)
                .ForeignKey("dbo.Lists", t => t.ListID)
                .Index(t => t.ListID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        PreviousMessageID = c.Int(nullable: false),
                        SenderUserID = c.Int(nullable: false),
                        ChatRoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.ChatRooms", t => t.ChatRoomID)
                .ForeignKey("dbo.Messages", t => t.PreviousMessageID)
                .ForeignKey("dbo.ListUsers", t => t.SenderUserID)
                .Index(t => t.PreviousMessageID)
                .Index(t => t.SenderUserID)
                .Index(t => t.ChatRoomID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserMtoMLists",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        ShoppingListID = c.Int(nullable: false),
                        Authority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.ShoppingListID })
                .ForeignKey("dbo.Lists", t => t.ShoppingListID)
                .ForeignKey("dbo.ListUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ShoppingListID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Hometown = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserMtoMLists", "UserID", "dbo.ListUsers");
            DropForeignKey("dbo.UserMtoMLists", "ShoppingListID", "dbo.Lists");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Messages", "SenderUserID", "dbo.ListUsers");
            DropForeignKey("dbo.Messages", "PreviousMessageID", "dbo.Messages");
            DropForeignKey("dbo.Messages", "ChatRoomID", "dbo.ChatRooms");
            DropForeignKey("dbo.ListItems", "ListID", "dbo.Lists");
            DropForeignKey("dbo.Friends", "UserID", "dbo.ListUsers");
            DropForeignKey("dbo.Friends", "FriendID", "dbo.ListUsers");
            DropForeignKey("dbo.ChatRoomUsers", "UserID", "dbo.ListUsers");
            DropForeignKey("dbo.ChatRoomUsers", "ChatRoomID", "dbo.ChatRooms");
            DropForeignKey("dbo.ChatRooms", "ShoppingListID", "dbo.Lists");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserMtoMLists", new[] { "ShoppingListID" });
            DropIndex("dbo.UserMtoMLists", new[] { "UserID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Messages", new[] { "ChatRoomID" });
            DropIndex("dbo.Messages", new[] { "SenderUserID" });
            DropIndex("dbo.Messages", new[] { "PreviousMessageID" });
            DropIndex("dbo.ListItems", new[] { "ListID" });
            DropIndex("dbo.Friends", new[] { "FriendID" });
            DropIndex("dbo.Friends", new[] { "UserID" });
            DropIndex("dbo.ChatRoomUsers", new[] { "UserID" });
            DropIndex("dbo.ChatRoomUsers", new[] { "ChatRoomID" });
            DropIndex("dbo.ChatRooms", new[] { "ShoppingListID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserMtoMLists");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Messages");
            DropTable("dbo.ListItems");
            DropTable("dbo.Friends");
            DropTable("dbo.Contacts");
            DropTable("dbo.ListUsers");
            DropTable("dbo.ChatRoomUsers");
            DropTable("dbo.Lists");
            DropTable("dbo.ChatRooms");
        }
    }
}
