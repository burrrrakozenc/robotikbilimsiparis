namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig181220201438 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "CreatedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "CreatedOn", c => c.DateTime());
        }
    }
}
