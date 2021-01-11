namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig07 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Baskets", "ID", "dbo.Users");
            DropForeignKey("dbo.Orders", "BasketID", "dbo.Baskets");
            DropIndex("dbo.Baskets", new[] { "ID" });
            DropPrimaryKey("dbo.Baskets");
            AddColumn("dbo.Baskets", "Code", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "BasketID", c => c.Int(nullable: true));
            AlterColumn("dbo.Baskets", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Baskets", "ID");
            CreateIndex("dbo.Users", "BasketID");
            AddForeignKey("dbo.Users", "BasketID", "dbo.Baskets", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "BasketID", "dbo.Baskets", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "BasketID", "dbo.Baskets");
            DropForeignKey("dbo.Users", "BasketID", "dbo.Baskets");
            DropIndex("dbo.Users", new[] { "BasketID" });
            DropPrimaryKey("dbo.Baskets");
            AlterColumn("dbo.Baskets", "ID", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "BasketID");
            DropColumn("dbo.Baskets", "Code");
            AddPrimaryKey("dbo.Baskets", "ID");
            CreateIndex("dbo.Baskets", "ID");
            AddForeignKey("dbo.Orders", "BasketID", "dbo.Baskets", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Baskets", "ID", "dbo.Users", "ID");
        }
    }
}
