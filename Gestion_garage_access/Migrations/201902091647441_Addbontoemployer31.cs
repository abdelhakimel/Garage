namespace Gestion_garage_access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addbontoemployer31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entreprises", "Tel", c => c.String(nullable: false));
            DropColumn("dbo.Entreprises", "Telp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Entreprises", "Telp", c => c.String(nullable: false));
            DropColumn("dbo.Entreprises", "Tel");
        }
    }
}
