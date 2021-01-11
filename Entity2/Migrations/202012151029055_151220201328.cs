namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _151220201328 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RoleID", c => c.Int());
            CreateIndex("dbo.Users", "RoleID");
            AddForeignKey("dbo.Users", "RoleID", "dbo.Roles", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropColumn("dbo.Users", "RoleID");
        }
    }
}
