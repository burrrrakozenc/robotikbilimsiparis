namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig171220200720 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRoleMappings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Roles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.RoleID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoleMappings", "UserID", "dbo.Users");
            DropForeignKey("dbo.UserRoleMappings", "RoleID", "dbo.Roles");
            DropIndex("dbo.UserRoleMappings", new[] { "UserID" });
            DropIndex("dbo.UserRoleMappings", new[] { "RoleID" });
            DropTable("dbo.UserRoleMappings");
        }
    }
}
