namespace ShoppingList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserStorage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Connections",
                c => new
                    {
                        ConnectionID = c.String(nullable: false, maxLength: 128),
                        UserAgent = c.String(),
                        Connected = c.Boolean(nullable: false),
                        User_UserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ConnectionID)
                .ForeignKey("dbo.Users", t => t.User_UserName)
                .Index(t => t.User_UserName);
            
            CreateTable(
                "dbo.ConversationRooms",
                c => new
                    {
                        RoomName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RoomName);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.UserConversationRooms",
                c => new
                    {
                        User_UserName = c.String(nullable: false, maxLength: 128),
                        ConversationRoom_RoomName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.User_UserName, t.ConversationRoom_RoomName })
                .ForeignKey("dbo.Users", t => t.User_UserName, cascadeDelete: true)
                .ForeignKey("dbo.ConversationRooms", t => t.ConversationRoom_RoomName, cascadeDelete: true)
                .Index(t => t.User_UserName)
                .Index(t => t.ConversationRoom_RoomName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserConversationRooms", "ConversationRoom_RoomName", "dbo.ConversationRooms");
            DropForeignKey("dbo.UserConversationRooms", "User_UserName", "dbo.Users");
            DropForeignKey("dbo.Connections", "User_UserName", "dbo.Users");
            DropIndex("dbo.UserConversationRooms", new[] { "ConversationRoom_RoomName" });
            DropIndex("dbo.UserConversationRooms", new[] { "User_UserName" });
            DropIndex("dbo.Connections", new[] { "User_UserName" });
            DropTable("dbo.UserConversationRooms");
            DropTable("dbo.Users");
            DropTable("dbo.ConversationRooms");
            DropTable("dbo.Connections");
        }
    }
}
