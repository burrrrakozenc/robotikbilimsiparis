namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig30 : DbMigration
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
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.ParentID)
                .Index(t => t.ParentID);
            
            AddColumn("dbo.Products", "CategoryID", c => c.Int());
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ParentID", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "ParentID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropColumn("dbo.Products", "CategoryID");
            DropTable("dbo.Categories");
        }
    }
}
