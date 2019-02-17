namespace Gestion_garage_access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addbontoemployer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bons", "Id_Entreprise", "dbo.Entreprises");
            DropIndex("dbo.Bons", new[] { "Id_Entreprise" });
            AddColumn("dbo.Bons", "Id_Enmployer", c => c.Int(nullable: false));
            CreateIndex("dbo.Bons", "Id_Enmployer");
            AddForeignKey("dbo.Bons", "Id_Enmployer", "dbo.Employers", "Id_Enmployer", cascadeDelete: true);
            DropColumn("dbo.Bons", "Id_Entreprise");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bons", "Id_Entreprise", c => c.Int(nullable: false));
            DropForeignKey("dbo.Bons", "Id_Enmployer", "dbo.Employers");
            DropIndex("dbo.Bons", new[] { "Id_Enmployer" });
            DropColumn("dbo.Bons", "Id_Enmployer");
            CreateIndex("dbo.Bons", "Id_Entreprise");
            AddForeignKey("dbo.Bons", "Id_Entreprise", "dbo.Entreprises", "Id_Entreprise", cascadeDelete: true);
        }
    }
}
