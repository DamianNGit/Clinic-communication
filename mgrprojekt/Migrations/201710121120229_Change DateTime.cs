namespace mgrprojekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wizytas", "DataWizyty", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wizytas", "DataWizyty", c => c.DateTime(nullable: false));
        }
    }
}
