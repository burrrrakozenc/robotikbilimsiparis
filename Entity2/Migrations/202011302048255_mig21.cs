namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig21 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BasketProducts", "CreatedOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BasketProducts", "CreatedOn", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
