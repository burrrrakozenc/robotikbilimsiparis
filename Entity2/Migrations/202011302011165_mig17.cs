namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig17 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BasketProducts", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Baskets", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orders", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Products", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Products", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orders", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Baskets", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.BasketProducts", "CreatedOn", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
