namespace mgrprojekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lekarzs",
                c => new
                    {
                        IdLekarz = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        NrTel = c.String(),
                        GodzinyPrzyjmowania = c.String(),
                        DniPrzyjowania = c.String(),
                        NrGabinetu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdLekarz);
            
            CreateTable(
                "dbo.Wizytas",
                c => new
                    {
                        IdWizyty = c.Int(nullable: false, identity: true),
                        DataWizyty = c.DateTime(nullable: false),
                        GodzinaWizyty = c.String(),
                        Lekarz_IdLekarz = c.Int(),
                        Pacjent_IdPacjenta = c.Int(),
                    })
                .PrimaryKey(t => t.IdWizyty)
                .ForeignKey("dbo.Lekarzs", t => t.Lekarz_IdLekarz)
                .ForeignKey("dbo.Pacjents", t => t.Pacjent_IdPacjenta)
                .Index(t => t.Lekarz_IdLekarz)
                .Index(t => t.Pacjent_IdPacjenta);
            
            CreateTable(
                "dbo.Pacjents",
                c => new
                    {
                        IdPacjenta = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        NrPSEL = c.String(),
                        NrTel = c.String(),
                        AdresZameldowania = c.String(),
                    })
                .PrimaryKey(t => t.IdPacjenta);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wizytas", "Pacjent_IdPacjenta", "dbo.Pacjents");
            DropForeignKey("dbo.Wizytas", "Lekarz_IdLekarz", "dbo.Lekarzs");
            DropIndex("dbo.Wizytas", new[] { "Pacjent_IdPacjenta" });
            DropIndex("dbo.Wizytas", new[] { "Lekarz_IdLekarz" });
            DropTable("dbo.Pacjents");
            DropTable("dbo.Wizytas");
            DropTable("dbo.Lekarzs");
        }
    }
}
