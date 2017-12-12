namespace Komponenten.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBenutzerKundeAdmin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bestellungs", "Kunde_KundenId", "dbo.Kundes");
            DropForeignKey("dbo.FilmBewertungs", "Kunde_KundenId", "dbo.Kundes");
            RenameColumn(table: "dbo.Bestellungs", name: "Kunde_KundenId", newName: "Kunde_BenutzerId");
            RenameColumn(table: "dbo.FilmBewertungs", name: "Kunde_KundenId", newName: "Kunde_BenutzerId");
            RenameIndex(table: "dbo.Bestellungs", name: "IX_Kunde_KundenId", newName: "IX_Kunde_BenutzerId");
            RenameIndex(table: "dbo.FilmBewertungs", name: "IX_Kunde_KundenId", newName: "IX_Kunde_BenutzerId");
            DropPrimaryKey("dbo.Admins");
            DropPrimaryKey("dbo.Kundes");
            DropColumn("dbo.Admins", "AdminId");
            DropColumn("dbo.Kundes", "KundenId");
            AddColumn("dbo.Admins", "BenutzerId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Kundes", "BenutzerId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Admins", "BenutzerId");
            AddPrimaryKey("dbo.Kundes", "BenutzerId");
            AddForeignKey("dbo.Bestellungs", "Kunde_BenutzerId", "dbo.Kundes", "BenutzerId");
            AddForeignKey("dbo.FilmBewertungs", "Kunde_BenutzerId", "dbo.Kundes", "BenutzerId");
            
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kundes", "KundenId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Admins", "AdminId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.FilmBewertungs", "Kunde_BenutzerId", "dbo.Kundes");
            DropForeignKey("dbo.Bestellungs", "Kunde_BenutzerId", "dbo.Kundes");
            DropPrimaryKey("dbo.Kundes");
            DropPrimaryKey("dbo.Admins");
            DropColumn("dbo.Kundes", "BenutzerId");
            DropColumn("dbo.Admins", "BenutzerId");
            AddPrimaryKey("dbo.Kundes", "KundenId");
            AddPrimaryKey("dbo.Admins", "AdminId");
            RenameIndex(table: "dbo.FilmBewertungs", name: "IX_Kunde_BenutzerId", newName: "IX_Kunde_KundenId");
            RenameIndex(table: "dbo.Bestellungs", name: "IX_Kunde_BenutzerId", newName: "IX_Kunde_KundenId");
            RenameColumn(table: "dbo.FilmBewertungs", name: "Kunde_BenutzerId", newName: "Kunde_KundenId");
            RenameColumn(table: "dbo.Bestellungs", name: "Kunde_BenutzerId", newName: "Kunde_KundenId");
            AddForeignKey("dbo.FilmBewertungs", "Kunde_KundenId", "dbo.Kundes", "KundenId");
            AddForeignKey("dbo.Bestellungs", "Kunde_KundenId", "dbo.Kundes", "KundenId");
        }
    }
}
