namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig181220200024 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "PaymentStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PaymentStatus");
            DropColumn("dbo.Orders", "OrderStatus");
        }
    }
}
