namespace Entity2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrole : DbMigration
    {
        public override void Up()
        {

            Sql("Insert into Roles(Name) Values ('SuperAdmin')");
            Sql("Insert into Roles(Name) Values ('Admin')");
            Sql("Insert into Roles(Name) Values ('Normal')");
        }
        
        public override void Down()
        {
        }
    }
}
