namespace BlackList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class message : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "ChatMessage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ChatMessage");
        }
    }
}
