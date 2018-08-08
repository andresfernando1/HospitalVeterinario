namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg14r3dd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Propietarios", "role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Propietarios", "role");
        }
    }
}
