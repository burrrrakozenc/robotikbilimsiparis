namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BasketProducts", "OrderID", "dbo.Orders");
            DropIndex("dbo.BasketProducts", new[] { "OrderID" });
            AlterColumn("dbo.BasketProducts", "OrderID", c => c.Int());
            CreateIndex("dbo.BasketProducts", "OrderID");
            AddForeignKey("dbo.BasketProducts", "OrderID", "dbo.Orders", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketProducts", "OrderID", "dbo.Orders");
            DropIndex("dbo.BasketProducts", new[] { "OrderID" });
            AlterColumn("dbo.BasketProducts", "OrderID", c => c.Int(nullable: false));
            CreateIndex("dbo.BasketProducts", "OrderID");
            AddForeignKey("dbo.BasketProducts", "OrderID", "dbo.Orders", "ID", cascadeDelete: true);
        }
    }
}
