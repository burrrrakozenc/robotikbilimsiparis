namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig40 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ExpectedDeliveryDate", c => c.DateTime());
            DropColumn("dbo.Orders", "ShipmentDetails");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "ShipmentDetails", c => c.String());
            DropColumn("dbo.Orders", "ExpectedDeliveryDate");
        }
    }
}
