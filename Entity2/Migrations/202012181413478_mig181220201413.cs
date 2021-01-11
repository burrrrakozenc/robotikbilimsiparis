namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig181220201413 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductPriceUSD", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ProductStock", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ProductImage", c => c.String());
            AddColumn("dbo.Products", "CategoryID", c => c.Int());
            AddColumn("dbo.Products", "CreatedOn", c => c.DateTime());
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropColumn("dbo.Products", "CreatedOn");
            DropColumn("dbo.Products", "CategoryID");
            DropColumn("dbo.Products", "ProductImage");
            DropColumn("dbo.Products", "ProductStock");
            DropColumn("dbo.Products", "ProductPriceUSD");
        }
    }
}
