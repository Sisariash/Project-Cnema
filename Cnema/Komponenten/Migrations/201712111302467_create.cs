namespace Komponenten.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Passwort = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Bestellungs",
                c => new
                    {
                        BestellId = c.Int(nullable: false, identity: true),
                        Preis = c.Double(nullable: false),
                        Kunde_KundenId = c.Int(),
                        Vorstellung_VorstellungId = c.Int(),
                    })
                .PrimaryKey(t => t.BestellId)
                .ForeignKey("dbo.Kundes", t => t.Kunde_KundenId)
                .ForeignKey("dbo.Vorstellungs", t => t.Vorstellung_VorstellungId)
                .Index(t => t.Kunde_KundenId)
                .Index(t => t.Vorstellung_VorstellungId);
            
            CreateTable(
                "dbo.Kundes",
                c => new
                    {
                        KundenId = c.Int(nullable: false, identity: true),
                        Passwort = c.String(nullable: false),
                        Vorname = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Geburtsdatum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KundenId);
            
            CreateTable(
                "dbo.FilmBewertungs",
                c => new
                    {
                        FilmBewertungId = c.Int(nullable: false, identity: true),
                        Bewertung = c.Int(nullable: false),
                        Film_FilmId = c.Int(),
                        Kunde_KundenId = c.Int(),
                    })
                .PrimaryKey(t => t.FilmBewertungId)
                .ForeignKey("dbo.Films", t => t.Film_FilmId)
                .ForeignKey("dbo.Kundes", t => t.Kunde_KundenId)
                .Index(t => t.Film_FilmId)
                .Index(t => t.Kunde_KundenId);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        Titel = c.String(),
                        Jahr = c.Int(nullable: false),
                        Genre = c.String(),
                        Laenge = c.Int(nullable: false),
                        Sprache = c.String(),
                        Is3D = c.Boolean(nullable: false),
                        BewertungAvg = c.Double(nullable: false),
                        Fsk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilmId);
            
            CreateTable(
                "dbo.Vorstellungs",
                c => new
                    {
                        VorstellungId = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Film_FilmId = c.Int(),
                        Saal_SaalName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VorstellungId)
                .ForeignKey("dbo.Films", t => t.Film_FilmId)
                .ForeignKey("dbo.Saals", t => t.Saal_SaalName)
                .Index(t => t.Film_FilmId)
                .Index(t => t.Saal_SaalName);
            
            CreateTable(
                "dbo.Saals",
                c => new
                    {
                        SaalName = c.String(nullable: false, maxLength: 128),
                        AnzahlSitze = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaalName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmBewertungs", "Kunde_KundenId", "dbo.Kundes");
            DropForeignKey("dbo.Vorstellungs", "Saal_SaalName", "dbo.Saals");
            DropForeignKey("dbo.Vorstellungs", "Film_FilmId", "dbo.Films");
            DropForeignKey("dbo.Bestellungs", "Vorstellung_VorstellungId", "dbo.Vorstellungs");
            DropForeignKey("dbo.FilmBewertungs", "Film_FilmId", "dbo.Films");
            DropForeignKey("dbo.Bestellungs", "Kunde_KundenId", "dbo.Kundes");
            DropIndex("dbo.Vorstellungs", new[] { "Saal_SaalName" });
            DropIndex("dbo.Vorstellungs", new[] { "Film_FilmId" });
            DropIndex("dbo.FilmBewertungs", new[] { "Kunde_KundenId" });
            DropIndex("dbo.FilmBewertungs", new[] { "Film_FilmId" });
            DropIndex("dbo.Bestellungs", new[] { "Vorstellung_VorstellungId" });
            DropIndex("dbo.Bestellungs", new[] { "Kunde_KundenId" });
            DropTable("dbo.Saals");
            DropTable("dbo.Vorstellungs");
            DropTable("dbo.Films");
            DropTable("dbo.FilmBewertungs");
            DropTable("dbo.Kundes");
            DropTable("dbo.Bestellungs");
            DropTable("dbo.Admins");
        }
    }
}
