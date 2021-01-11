namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig08 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BasketProducts", "ProductID");
            CreateIndex("dbo.BasketProducts", "BasketID");
            AddForeignKey("dbo.BasketProducts", "BasketID", "dbo.Baskets", "ID", cascadeDelete: true);
            AddForeignKey("dbo.BasketProducts", "ProductID", "dbo.Products", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.BasketProducts", "BasketID", "dbo.Baskets");
            DropIndex("dbo.BasketProducts", new[] { "BasketID" });
            DropIndex("dbo.BasketProducts", new[] { "ProductID" });
        }
    }
}
