namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasketProducts", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BasketProducts", "CreatedOn");
        }
    }
}
