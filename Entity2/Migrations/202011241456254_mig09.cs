namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig09 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BasketProducts", "BasketID", "dbo.Baskets");
            DropIndex("dbo.BasketProducts", new[] { "BasketID" });
            AlterColumn("dbo.BasketProducts", "BasketID", c => c.Int());
            CreateIndex("dbo.BasketProducts", "BasketID");
            CreateIndex("dbo.BasketProducts", "OrderID");
            AddForeignKey("dbo.BasketProducts", "OrderID", "dbo.Orders", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BasketProducts", "BasketID", "dbo.Baskets", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketProducts", "BasketID", "dbo.Baskets");
            DropForeignKey("dbo.BasketProducts", "OrderID", "dbo.Orders");
            DropIndex("dbo.BasketProducts", new[] { "OrderID" });
            DropIndex("dbo.BasketProducts", new[] { "BasketID" });
            AlterColumn("dbo.BasketProducts", "BasketID", c => c.Int(nullable: false));
            CreateIndex("dbo.BasketProducts", "BasketID");
            AddForeignKey("dbo.BasketProducts", "BasketID", "dbo.Baskets", "ID", cascadeDelete: true);
        }
    }
}
