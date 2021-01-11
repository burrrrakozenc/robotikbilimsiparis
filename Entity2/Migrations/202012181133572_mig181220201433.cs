namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig181220201433 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductPriceUSD", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductPriceUSD");
        }
    }
}
