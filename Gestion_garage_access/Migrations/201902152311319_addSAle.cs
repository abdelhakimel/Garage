namespace Gestion_garage_access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSAle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SaleClasses",
                c => new
                    {
                        Id_sale = c.Int(nullable: false, identity: true),
                        Number = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Piece_Id_piece = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id_sale)
                .ForeignKey("dbo.Pieces", t => t.Piece_Id_piece, cascadeDelete: true)
                .Index(t => t.Piece_Id_piece);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaleClasses", "Piece_Id_piece", "dbo.Pieces");
            DropIndex("dbo.SaleClasses", new[] { "Piece_Id_piece" });
            DropTable("dbo.SaleClasses");
        }
    }
}
