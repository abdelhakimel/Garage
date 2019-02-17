namespace Gestion_garage_access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addbons : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bons",
                c => new
                    {
                        Id_Bon = c.Int(nullable: false, identity: true),
                        TotalePrix = c.Double(nullable: false),
                        FirstPrix = c.Double(nullable: false),
                        RestPrix = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Id_Entreprise = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Bon)
                .ForeignKey("dbo.Entreprises", t => t.Id_Entreprise, cascadeDelete: true)
                .Index(t => t.Id_Entreprise);
            
            CreateTable(
                "dbo.Entreprises",
                c => new
                    {
                        Id_Entreprise = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Telp = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Entreprise);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id_Enmployer = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Tel = c.String(),
                        Id_Entreprise = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_Enmployer)
                .ForeignKey("dbo.Entreprises", t => t.Id_Entreprise, cascadeDelete: true)
                .Index(t => t.Id_Entreprise);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employers", "Id_Entreprise", "dbo.Entreprises");
            DropForeignKey("dbo.Bons", "Id_Entreprise", "dbo.Entreprises");
            DropIndex("dbo.Employers", new[] { "Id_Entreprise" });
            DropIndex("dbo.Bons", new[] { "Id_Entreprise" });
            DropTable("dbo.Employers");
            DropTable("dbo.Entreprises");
            DropTable("dbo.Bons");
        }
    }
}
