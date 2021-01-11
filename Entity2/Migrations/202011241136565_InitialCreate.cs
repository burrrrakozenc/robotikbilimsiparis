namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketProducts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        BasketID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SubTotal = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BasketID = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Baskets", t => t.BasketID, cascadeDelete: true)
                .Index(t => t.BasketID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductPrice = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BasketID = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Baskets", t => t.BasketID, cascadeDelete: true)
                .Index(t => t.BasketID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "BasketID", "dbo.Baskets");
            DropForeignKey("dbo.Orders", "BasketID", "dbo.Baskets");
            DropIndex("dbo.Users", new[] { "BasketID" });
            DropIndex("dbo.Orders", new[] { "BasketID" });
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Baskets");
            DropTable("dbo.BasketProducts");
        }
    }
}
