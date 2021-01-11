namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig181220201437 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropColumn("dbo.Products", "ProductPriceUSD");
            DropColumn("dbo.Products", "ProductStock");
            DropColumn("dbo.Products", "ProductImage");
            DropColumn("dbo.Products", "CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CategoryID", c => c.Int());
            AddColumn("dbo.Products", "ProductImage", c => c.String());
            AddColumn("dbo.Products", "ProductStock", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ProductPriceUSD", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "ID");
        }
    }
}
