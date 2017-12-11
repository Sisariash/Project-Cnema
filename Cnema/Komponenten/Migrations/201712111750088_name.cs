namespace Komponenten.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Passwort", c => c.String());
            AlterColumn("dbo.Admins", "Name", c => c.String());
            AlterColumn("dbo.Kundes", "Passwort", c => c.String());
            AlterColumn("dbo.Kundes", "Vorname", c => c.String());
            AlterColumn("dbo.Kundes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kundes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Kundes", "Vorname", c => c.String(nullable: false));
            AlterColumn("dbo.Kundes", "Passwort", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "Passwort", c => c.String(nullable: false));
        }
    }
}
