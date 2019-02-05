namespace MVCLoginPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateAndNumberOfStockInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
        }
    }
}
