namespace BlackList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minorupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "ChatMessage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "ChatMessage", c => c.String());
        }
    }
}
