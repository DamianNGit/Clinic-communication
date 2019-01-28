namespace mgrprojekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zmianywtabeli : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PracownikObslugis",
                c => new
                    {
                        IdPracownika = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Haslo = c.String(),
                    })
                .PrimaryKey(t => t.IdPracownika);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PracownikObslugis");
        }
    }
}
