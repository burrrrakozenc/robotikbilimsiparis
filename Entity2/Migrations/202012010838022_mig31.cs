namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig31 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "ParentID", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "ParentID" });
            AddColumn("dbo.Categories", "Category_ID", c => c.Int());
            AlterColumn("dbo.BasketProducts", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Baskets", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Orders", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Products", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime());
            CreateIndex("dbo.Categories", "Category_ID");
            AddForeignKey("dbo.Categories", "Category_ID", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "Category_ID" });
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Products", "CreatedOn", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Orders", "CreatedOn", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Baskets", "CreatedOn", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.BasketProducts", "CreatedOn", c => c.DateTime(storeType: "date"));
            DropColumn("dbo.Categories", "Category_ID");
            CreateIndex("dbo.Categories", "ParentID");
            AddForeignKey("dbo.Categories", "ParentID", "dbo.Categories", "ID");
        }
    }
}
