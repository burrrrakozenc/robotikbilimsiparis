namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _151220201538 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserName");
        }
    }
}
