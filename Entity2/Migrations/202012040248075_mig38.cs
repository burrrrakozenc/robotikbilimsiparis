namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig38 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShipmentStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "LastStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "LastStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "ShipmentStatus");
        }
    }
}
