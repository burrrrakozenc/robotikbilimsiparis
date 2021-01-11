namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig181220200403 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DeliveryStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "DeliveryStatus");
        }
    }
}
