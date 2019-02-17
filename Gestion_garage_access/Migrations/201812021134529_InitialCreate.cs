namespace Gestion_garage_access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pieces",
                c => new
                    {
                        Ref_piece = c.String(nullable: false, maxLength: 30),
                        Nom_piece = c.String(nullable: false, maxLength: 30),
                        Prix_achat = c.Double(nullable: false),
                        Prix_vente = c.Double(nullable: false),
                        Cars = c.String(nullable: false),
                        Quantite = c.Double(nullable: false),
                        Unite = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Ref_piece);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pieces");
        }
    }
}
