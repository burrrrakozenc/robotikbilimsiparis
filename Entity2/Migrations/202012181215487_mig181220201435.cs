namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig181220201435 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ProductPrice", c => c.Int(nullable: false));
        }
    }
}
