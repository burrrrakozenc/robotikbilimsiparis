namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ShipmentNo", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ShipmentDetails", c => c.String());
            AddColumn("dbo.Products", "ProductImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductImage");
            DropColumn("dbo.Orders", "ShipmentDetails");
            DropColumn("dbo.Orders", "ShipmentNo");
        }
    }
}
