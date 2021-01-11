namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _151220201400 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Roles", "Accountant");
            DropColumn("dbo.Roles", "Storage");
            DropColumn("dbo.Roles", "Shipment");
            DropColumn("dbo.Roles", "User");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "User", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "Shipment", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "Storage", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "Accountant", c => c.Boolean(nullable: false));
        }
    }
}
