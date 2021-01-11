namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig181220201436 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BasketProducts", "SubTotal", c => c.Double(nullable: false));
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.BasketProducts", "SubTotal", c => c.Int(nullable: false));
        }
    }
}
