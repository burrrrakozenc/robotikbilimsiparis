namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig41 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "ShipmentNo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "ShipmentNo", c => c.Int(nullable: false));
        }
    }
}
