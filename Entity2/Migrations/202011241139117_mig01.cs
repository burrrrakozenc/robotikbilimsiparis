namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig01 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BasketProducts", "CreatedOn");
            DropColumn("dbo.Baskets", "CreatedOn");
            DropColumn("dbo.Orders", "CreatedOn");
            DropColumn("dbo.Products", "CreatedOn");
            DropColumn("dbo.Users", "CreatedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Baskets", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.BasketProducts", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
