namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasketProducts", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Baskets", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CreatedOn");
            DropColumn("dbo.Products", "CreatedOn");
            DropColumn("dbo.Orders", "CreatedOn");
            DropColumn("dbo.Baskets", "CreatedOn");
            DropColumn("dbo.BasketProducts", "CreatedOn");
        }
    }
}
