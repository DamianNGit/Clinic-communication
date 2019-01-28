namespace mgrprojekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolePracownikOb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PracownikObslugis", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PracownikObslugis", "Role");
        }
    }
}
