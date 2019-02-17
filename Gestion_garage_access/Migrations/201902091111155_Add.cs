namespace Gestion_garage_access.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Pieces");
            AddColumn("dbo.Pieces", "Id_piece", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Pieces", "Qualite", c => c.String(nullable: false));
            AlterColumn("dbo.Pieces", "Ref_piece", c => c.String(maxLength: 30));
            AddPrimaryKey("dbo.Pieces", "Id_piece");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Pieces");
            AlterColumn("dbo.Pieces", "Ref_piece", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Pieces", "Qualite");
            DropColumn("dbo.Pieces", "Id_piece");
            AddPrimaryKey("dbo.Pieces", "Ref_piece");
        }
    }
}
