namespace BlackList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        FriendID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.FriendID })
                .ForeignKey("dbo.Users", t => t.FriendID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.FriendID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Mail = c.String(),
                        IsMailVerified = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.ListItems",
                c => new
                    {
                        ListItemID = c.Int(nullable: false, identity: true),
                        ItemName = c.String(nullable: false),
                        ListID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListItemID)
                .ForeignKey("dbo.ShoppingLists", t => t.ListID)
                .Index(t => t.ListID);
            
            CreateTable(
                "dbo.ShoppingLists",
                c => new
                    {
                        ShoppingListID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingListID);
            
            CreateTable(
                "dbo.UserMtoMLists",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        ShoppingListID = c.Int(nullable: false),
                        Authority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.ShoppingListID })
                .ForeignKey("dbo.ShoppingLists", t => t.ShoppingListID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ShoppingListID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMtoMLists", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserMtoMLists", "ShoppingListID", "dbo.ShoppingLists");
            DropForeignKey("dbo.ListItems", "ListID", "dbo.ShoppingLists");
            DropForeignKey("dbo.Friends", "UserID", "dbo.Users");
            DropForeignKey("dbo.Friends", "FriendID", "dbo.Users");
            DropIndex("dbo.UserMtoMLists", new[] { "ShoppingListID" });
            DropIndex("dbo.UserMtoMLists", new[] { "UserID" });
            DropIndex("dbo.ListItems", new[] { "ListID" });
            DropIndex("dbo.Friends", new[] { "FriendID" });
            DropIndex("dbo.Friends", new[] { "UserID" });
            DropTable("dbo.UserMtoMLists");
            DropTable("dbo.ShoppingLists");
            DropTable("dbo.ListItems");
            DropTable("dbo.Users");
            DropTable("dbo.Friends");
        }
    }
}
