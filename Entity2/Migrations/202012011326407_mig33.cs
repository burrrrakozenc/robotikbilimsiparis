namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig33 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        ParentID = c.Int(),
                        Category_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
            AddColumn("dbo.Orders", "ShipmentNo", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ShipmentDetails", c => c.String());
            AddColumn("dbo.Products", "ProductImage", c => c.String());
            AddColumn("dbo.Products", "CategoryID", c => c.Int());
            AlterColumn("dbo.BasketProducts", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Baskets", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Orders", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Products", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime());
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "Category_ID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Products", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orders", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Baskets", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.BasketProducts", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Products", "CategoryID");
            DropColumn("dbo.Products", "ProductImage");
            DropColumn("dbo.Orders", "ShipmentDetails");
            DropColumn("dbo.Orders", "ShipmentNo");
            DropTable("dbo.Categories");
        }
    }
}
