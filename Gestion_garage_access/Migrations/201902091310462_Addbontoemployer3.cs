namespace Gestion_garage_access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addbontoemployer3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bons", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bons", "Date");
        }
    }
}
