namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig03 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "BasketID", "dbo.Baskets");
            DropForeignKey("dbo.Orders", "BasketID", "dbo.Baskets");
            DropIndex("dbo.Users", new[] { "BasketID" });
            DropPrimaryKey("dbo.Baskets");
            AlterColumn("dbo.Baskets", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Baskets", "ID");
            CreateIndex("dbo.Baskets", "ID");
            AddForeignKey("dbo.Baskets", "ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Orders", "BasketID", "dbo.Baskets", "ID", cascadeDelete: true);
            DropColumn("dbo.Users", "BasketID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "BasketID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "BasketID", "dbo.Baskets");
            DropForeignKey("dbo.Baskets", "ID", "dbo.Users");
            DropIndex("dbo.Baskets", new[] { "ID" });
            DropPrimaryKey("dbo.Baskets");
            AlterColumn("dbo.Baskets", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Baskets", "ID");
            CreateIndex("dbo.Users", "BasketID");
            AddForeignKey("dbo.Orders", "BasketID", "dbo.Baskets", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Users", "BasketID", "dbo.Baskets", "ID", cascadeDelete: true);
        }
    }
}
