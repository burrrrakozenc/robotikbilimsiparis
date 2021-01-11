namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UserSubmit", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "AccountingStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "StoreStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "LastStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "LastStatus");
            DropColumn("dbo.Orders", "StoreStatus");
            DropColumn("dbo.Orders", "AccountingStatus");
            DropColumn("dbo.Orders", "UserSubmit");
        }
    }
}
