namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mcashcvjf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Controls", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Controls", new[] { "user_Id" });
            AddColumn("dbo.Controls", "veterinarioFK", c => c.String(maxLength: 128));
            CreateIndex("dbo.Controls", "veterinarioFK");
            AddForeignKey("dbo.Controls", "veterinarioFK", "dbo.Veterinarios", "ID");
            DropColumn("dbo.Controls", "userFK");
            DropColumn("dbo.Controls", "user_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Controls", "user_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Controls", "userFK", c => c.String());
            DropForeignKey("dbo.Controls", "veterinarioFK", "dbo.Veterinarios");
            DropIndex("dbo.Controls", new[] { "veterinarioFK" });
            DropColumn("dbo.Controls", "veterinarioFK");
            CreateIndex("dbo.Controls", "user_Id");
            AddForeignKey("dbo.Controls", "user_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
