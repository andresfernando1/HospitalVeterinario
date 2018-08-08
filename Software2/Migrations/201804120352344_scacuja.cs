namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scacuja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Veterinarios", "role", c => c.String());
            DropColumn("dbo.Propietarios", "role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Propietarios", "role", c => c.String());
            DropColumn("dbo.Veterinarios", "role");
        }
    }
}
