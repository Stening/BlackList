namespace BlackList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_bool_listItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListItems", "IsChecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ListItems", "IsChecked");
        }
    }
}
