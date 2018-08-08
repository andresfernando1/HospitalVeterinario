namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1ds : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Practicantes", "password");
            DropColumn("dbo.Practicantes", "repetirPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Practicantes", "repetirPassword", c => c.String(nullable: false));
            AddColumn("dbo.Practicantes", "password", c => c.String(nullable: false));
        }
    }
}
