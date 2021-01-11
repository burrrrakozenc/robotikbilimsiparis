namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig171220200836 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoleMappings", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.UserRoleMappings", "UserID", "dbo.Users");
            DropIndex("dbo.UserRoleMappings", new[] { "RoleID" });
            DropIndex("dbo.UserRoleMappings", new[] { "UserID" });
            AddColumn("dbo.Users", "RoleID", c => c.Int());
            CreateIndex("dbo.Users", "RoleID");
            AddForeignKey("dbo.Users", "RoleID", "dbo.Roles", "ID");
            DropColumn("dbo.UserRoleMappings", "RoleID");
            DropColumn("dbo.UserRoleMappings", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserRoleMappings", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.UserRoleMappings", "RoleID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropColumn("dbo.Users", "RoleID");
            CreateIndex("dbo.UserRoleMappings", "UserID");
            CreateIndex("dbo.UserRoleMappings", "RoleID");
            AddForeignKey("dbo.UserRoleMappings", "UserID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.UserRoleMappings", "RoleID", "dbo.Roles", "ID", cascadeDelete: true);
        }
    }
}
