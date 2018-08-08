namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mdbsj : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Formulae", "practicanteID", "dbo.Practicantes");
            DropForeignKey("dbo.Remisions", "practicanteID", "dbo.Practicantes");
            DropForeignKey("dbo.SolicitudExamen", "idPracticante", "dbo.Practicantes");
            DropIndex("dbo.Formulae", new[] { "practicanteID" });
            DropIndex("dbo.Remisions", new[] { "practicanteID" });
            DropIndex("dbo.SolicitudExamen", new[] { "idPracticante" });
            CreateTable(
                "dbo.Veterinarios",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        correo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Controls", "userFK", c => c.String());
            AddColumn("dbo.Controls", "user_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Formulae", "veterinarioD", c => c.String(maxLength: 128));
            AddColumn("dbo.Remisions", "veterinarioID", c => c.String(maxLength: 128));
            AddColumn("dbo.SolicitudExamen", "veterinarioFK", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Controls", "user_Id");
            CreateIndex("dbo.Formulae", "veterinarioD");
            CreateIndex("dbo.Remisions", "veterinarioID");
            CreateIndex("dbo.SolicitudExamen", "veterinarioFK");
            AddForeignKey("dbo.Controls", "user_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Formulae", "veterinarioD", "dbo.Veterinarios", "ID");
            AddForeignKey("dbo.Remisions", "veterinarioID", "dbo.Veterinarios", "ID");
            AddForeignKey("dbo.SolicitudExamen", "veterinarioFK", "dbo.Veterinarios", "ID", cascadeDelete: true);
            DropColumn("dbo.Formulae", "practicanteID");
            DropColumn("dbo.Remisions", "practicanteID");
            DropColumn("dbo.SolicitudExamen", "idPracticante");
            DropTable("dbo.Practicantes");
            DropTable("dbo.Doctors");
            DropTable("dbo.Medicos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        medicoID = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        password = c.String(nullable: false),
                        repetirPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.medicoID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        cedula = c.String(nullable: false, maxLength: 15),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.cedula);
            
            CreateTable(
                "dbo.Practicantes",
                c => new
                    {
                        practicanteID = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        correo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.practicanteID);
            
            AddColumn("dbo.SolicitudExamen", "idPracticante", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Remisions", "practicanteID", c => c.String(maxLength: 128));
            AddColumn("dbo.Formulae", "practicanteID", c => c.String(maxLength: 128));
            DropForeignKey("dbo.SolicitudExamen", "veterinarioFK", "dbo.Veterinarios");
            DropForeignKey("dbo.Remisions", "veterinarioID", "dbo.Veterinarios");
            DropForeignKey("dbo.Formulae", "veterinarioD", "dbo.Veterinarios");
            DropForeignKey("dbo.Controls", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SolicitudExamen", new[] { "veterinarioFK" });
            DropIndex("dbo.Remisions", new[] { "veterinarioID" });
            DropIndex("dbo.Formulae", new[] { "veterinarioD" });
            DropIndex("dbo.Controls", new[] { "user_Id" });
            DropColumn("dbo.SolicitudExamen", "veterinarioFK");
            DropColumn("dbo.Remisions", "veterinarioID");
            DropColumn("dbo.Formulae", "veterinarioD");
            DropColumn("dbo.Controls", "user_Id");
            DropColumn("dbo.Controls", "userFK");
            DropTable("dbo.Veterinarios");
            CreateIndex("dbo.SolicitudExamen", "idPracticante");
            CreateIndex("dbo.Remisions", "practicanteID");
            CreateIndex("dbo.Formulae", "practicanteID");
            AddForeignKey("dbo.SolicitudExamen", "idPracticante", "dbo.Practicantes", "practicanteID", cascadeDelete: true);
            AddForeignKey("dbo.Remisions", "practicanteID", "dbo.Practicantes", "practicanteID");
            AddForeignKey("dbo.Formulae", "practicanteID", "dbo.Practicantes", "practicanteID");
        }
    }
}
