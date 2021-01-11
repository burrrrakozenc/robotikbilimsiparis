namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig37 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Ateilers", newName: "Ateliers");
            DropForeignKey("dbo.Addresses", "Ateiler_ID", "dbo.Ateilers");
            DropIndex("dbo.Addresses", new[] { "Ateiler_ID" });
            DropIndex("dbo.Users", new[] { "Ateiler_ID" });
            DropColumn("dbo.Addresses", "AtelierID");
            DropColumn("dbo.Users", "AtelierID");
            RenameColumn(table: "dbo.Addresses", name: "Ateiler_ID", newName: "AtelierID");
            RenameColumn(table: "dbo.Users", name: "Ateiler_ID", newName: "AtelierID");
            AlterColumn("dbo.Addresses", "AtelierID", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "AtelierID", c => c.Int());
            CreateIndex("dbo.Addresses", "AtelierID");
            CreateIndex("dbo.Users", "AtelierID");
            AddForeignKey("dbo.Addresses", "AtelierID", "dbo.Ateliers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "AtelierID", "dbo.Ateliers");
            DropIndex("dbo.Users", new[] { "AtelierID" });
            DropIndex("dbo.Addresses", new[] { "AtelierID" });
            AlterColumn("dbo.Users", "AtelierID", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "AtelierID", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "AtelierID", newName: "Ateiler_ID");
            RenameColumn(table: "dbo.Addresses", name: "AtelierID", newName: "Ateiler_ID");
            AddColumn("dbo.Users", "AtelierID", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "AtelierID", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "Ateiler_ID");
            CreateIndex("dbo.Addresses", "Ateiler_ID");
            AddForeignKey("dbo.Addresses", "Ateiler_ID", "dbo.Ateilers", "ID");
            RenameTable(name: "dbo.Ateliers", newName: "Ateilers");
        }
    }
}
