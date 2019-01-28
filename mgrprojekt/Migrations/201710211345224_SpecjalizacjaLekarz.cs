namespace mgrprojekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecjalizacjaLekarz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lekarzs", "Specjalizacja", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lekarzs", "Specjalizacja");
        }
    }
}
