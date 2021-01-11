namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig211220201048 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserRoleMappings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoleMappings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
