namespace mgrprojekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredfields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pacjents", "Imie", c => c.String(nullable: false));
            AlterColumn("dbo.Pacjents", "Nazwisko", c => c.String(nullable: false));
            AlterColumn("dbo.Pacjents", "NrPSEL", c => c.String(nullable: false));
            AlterColumn("dbo.Pacjents", "NrTel", c => c.String(nullable: false));
            AlterColumn("dbo.Pacjents", "AdresZameldowania", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pacjents", "AdresZameldowania", c => c.String());
            AlterColumn("dbo.Pacjents", "NrTel", c => c.String());
            AlterColumn("dbo.Pacjents", "NrPSEL", c => c.String());
            AlterColumn("dbo.Pacjents", "Nazwisko", c => c.String());
            AlterColumn("dbo.Pacjents", "Imie", c => c.String());
        }
    }
}
