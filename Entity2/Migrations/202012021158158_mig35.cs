namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig35 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ateilers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        AtelierID = c.Int(nullable: false),
                        Phone = c.String(),
                        Ateiler_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ateilers", t => t.Ateiler_ID)
                .Index(t => t.Ateiler_ID);
            
            AddColumn("dbo.Users", "AtelierID", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Ateiler_ID", c => c.Int());
            CreateIndex("dbo.Users", "Ateiler_ID");
            AddForeignKey("dbo.Users", "Ateiler_ID", "dbo.Ateilers", "ID");
            DropColumn("dbo.Users", "BranchOffice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "BranchOffice", c => c.String());
            DropForeignKey("dbo.Users", "Ateiler_ID", "dbo.Ateilers");
            DropForeignKey("dbo.Addresses", "Ateiler_ID", "dbo.Ateilers");
            DropIndex("dbo.Addresses", new[] { "Ateiler_ID" });
            DropIndex("dbo.Users", new[] { "Ateiler_ID" });
            DropColumn("dbo.Users", "Ateiler_ID");
            DropColumn("dbo.Users", "AtelierID");
            DropTable("dbo.Addresses");
            DropTable("dbo.Ateilers");
        }
    }
}
