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
                        ListID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChatRoomID)
                .ForeignKey("dbo.CheckLists", t => t.ListID)
                .Index(t => t.ListID);
            
            CreateTable(
                "dbo.CheckLists",
                c => new
                    {
                        ListID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ListID);
            
            CreateTable(
                "dbo.ChatRoomUsers",
                c => new
                    {
                        ChatRoomID = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ChatRoomID, t.UserId })
                .ForeignKey("dbo.ChatRooms", t => t.ChatRoomID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ChatRoomID)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Hometown = c.String(),
                        Name = c.String(),
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                        UserID = c.String(nullable: false, maxLength: 128),
                        FriendID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserID, t.FriendID })
                .ForeignKey("dbo.AspNetUsers", t => t.FriendID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
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
                .ForeignKey("dbo.CheckLists", t => t.ListID)
                .Index(t => t.ListID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        TimeStamp = c.DateTime(nullable: false),
                        PreviousMessageID = c.Int(nullable: false),
                        SenderUserID = c.String(nullable: false, maxLength: 128),
                        ChatRoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID)
                .ForeignKey("dbo.ChatRooms", t => t.ChatRoomID)
                .ForeignKey("dbo.Messages", t => t.PreviousMessageID)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderUserID)
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
                "dbo.UserMtoMLists",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        ListID = c.Int(nullable: false),
                        Authority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.ListID })
                .ForeignKey("dbo.CheckLists", t => t.ListID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ListID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMtoMLists", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserMtoMLists", "ListID", "dbo.CheckLists");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Messages", "SenderUserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "PreviousMessageID", "dbo.Messages");
            DropForeignKey("dbo.Messages", "ChatRoomID", "dbo.ChatRooms");
            DropForeignKey("dbo.ListItems", "ListID", "dbo.CheckLists");
            DropForeignKey("dbo.Friends", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "FriendID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChatRoomUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChatRoomUsers", "ChatRoomID", "dbo.ChatRooms");
            DropForeignKey("dbo.ChatRooms", "ListID", "dbo.CheckLists");
            DropIndex("dbo.UserMtoMLists", new[] { "ListID" });
            DropIndex("dbo.UserMtoMLists", new[] { "UserID" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Messages", new[] { "ChatRoomID" });
            DropIndex("dbo.Messages", new[] { "SenderUserID" });
            DropIndex("dbo.Messages", new[] { "PreviousMessageID" });
            DropIndex("dbo.ListItems", new[] { "ListID" });
            DropIndex("dbo.Friends", new[] { "FriendID" });
            DropIndex("dbo.Friends", new[] { "UserID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ChatRoomUsers", new[] { "UserId" });
            DropIndex("dbo.ChatRoomUsers", new[] { "ChatRoomID" });
            DropIndex("dbo.ChatRooms", new[] { "ListID" });
            DropTable("dbo.UserMtoMLists");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Messages");
            DropTable("dbo.ListItems");
            DropTable("dbo.Friends");
            DropTable("dbo.Contacts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ChatRoomUsers");
            DropTable("dbo.CheckLists");
            DropTable("dbo.ChatRooms");
        }
    }
}
