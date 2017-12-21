namespace Komponenten.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Offset : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC CHECKIDENT ('dbo.Kundes', RESEED, 1000);");
            Sql("DBCC CHECKIDENT ('dbo.Admins', RESEED, 10);");
        }
        
        public override void Down()
        {
        }
    }
}
