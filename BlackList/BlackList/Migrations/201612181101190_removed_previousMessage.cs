namespace BlackList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_previousMessage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "PreviousMessageID", "dbo.Messages");
            DropIndex("dbo.Messages", new[] { "PreviousMessageID" });
            DropColumn("dbo.Messages", "PreviousMessageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "PreviousMessageID", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", "PreviousMessageID");
            AddForeignKey("dbo.Messages", "PreviousMessageID", "dbo.Messages", "MessageID");
        }
    }
}
