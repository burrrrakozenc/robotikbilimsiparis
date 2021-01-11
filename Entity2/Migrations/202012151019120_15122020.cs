namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15122020 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Accountant", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "Storage", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "Shipment", c => c.Boolean(nullable: false));
            AddColumn("dbo.Roles", "User", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "User");
            DropColumn("dbo.Roles", "Shipment");
            DropColumn("dbo.Roles", "Storage");
            DropColumn("dbo.Roles", "Accountant");
        }
    }
}
