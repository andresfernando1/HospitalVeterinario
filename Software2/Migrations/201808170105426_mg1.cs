namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradors",
                c => new
                    {
                        adminID = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        password = c.String(nullable: false),
                        repetirPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.adminID);
            
            CreateTable(
                "dbo.Auto_Cirugia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        observaciones = c.String(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        historia = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historia)
                .Index(t => t.historia);
            
            CreateTable(
                "dbo.HistoriaClinicas",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        fecha_creacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Mascotas", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.Auto_Consentimiento",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        valor = c.Double(nullable: false),
                        interes = c.Double(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        historia = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historia)
                .Index(t => t.historia);
            
            CreateTable(
                "dbo.Controls",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        fecha = c.DateTime(nullable: false),
                        historia = c.String(maxLength: 128),
                        anamnesis = c.String(nullable: false),
                        temperatura = c.Double(nullable: false),
                        fc = c.Double(nullable: false),
                        mucosas = c.String(),
                        fr = c.Double(nullable: false),
                        tiempo = c.Double(nullable: false),
                        masacorporal = c.Double(nullable: false),
                        piel = c.Int(nullable: false),
                        muscolo = c.Int(nullable: false),
                        ojos = c.Int(nullable: false),
                        cardiovascular = c.Int(nullable: false),
                        respiratorio = c.Int(nullable: false),
                        digestivo = c.Int(nullable: false),
                        genito = c.Int(nullable: false),
                        reproducor = c.Int(nullable: false),
                        nervioso = c.Int(nullable: false),
                        linfatico = c.Int(nullable: false),
                        des_piel = c.String(),
                        des_muscolo = c.String(),
                        des_ojos = c.String(),
                        des_cardiovascular = c.String(),
                        des_respiratorio = c.String(),
                        des_digestivo = c.String(),
                        des_genito = c.String(),
                        des_reproducor = c.String(),
                        des_nervioso = c.String(),
                        des_linfatico = c.String(),
                        anormalidades = c.String(),
                        problemas = c.String(),
                        ayudas = c.String(),
                        fianl = c.String(nullable: false),
                        veterinarioFK = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historia)
                .ForeignKey("dbo.Veterinarios", t => t.veterinarioFK)
                .Index(t => t.historia)
                .Index(t => t.veterinarioFK);
            
            CreateTable(
                "dbo.Veterinarios",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        correo = c.String(nullable: false),
                        role = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Auto_Eutanasia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        causa = c.String(nullable: false),
                        seccion = c.String(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        historia = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historia)
                .Index(t => t.historia);
            
            CreateTable(
                "dbo.Formulae",
                c => new
                    {
                        formulaID = c.Int(nullable: false, identity: true),
                        historiaFK = c.String(maxLength: 128),
                        fecha = c.DateTime(nullable: false),
                        veterinarioD = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.formulaID)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historiaFK)
                .ForeignKey("dbo.Veterinarios", t => t.veterinarioD)
                .Index(t => t.historiaFK)
                .Index(t => t.veterinarioD);
            
            CreateTable(
                "dbo.Medicamentoes",
                c => new
                    {
                        medicamentoID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        dosis = c.Int(nullable: false),
                        lote = c.Int(nullable: false),
                        viaSuministro = c.Int(nullable: false),
                        frecuencia = c.String(),
                        cantidad = c.Int(nullable: false),
                        Formula_formulaID = c.Int(),
                    })
                .PrimaryKey(t => t.medicamentoID)
                .ForeignKey("dbo.Formulae", t => t.Formula_formulaID)
                .Index(t => t.Formula_formulaID);
            
            CreateTable(
                "dbo.GestionVacunacions",
                c => new
                    {
                        vacunaID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        fechaVacunacion = c.DateTime(nullable: false),
                        dosis = c.Double(nullable: false),
                        lote = c.Double(nullable: false),
                        historiaFK = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.vacunaID)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historiaFK)
                .Index(t => t.historiaFK);
            
            CreateTable(
                "dbo.Mascotas",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(nullable: false),
                        fecha_nacimiento = c.DateTime(nullable: false),
                        sexo = c.Int(nullable: false),
                        color = c.Int(nullable: false),
                        razaFK = c.Int(nullable: false),
                        propietario = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Propietarios", t => t.propietario, cascadeDelete: true)
                .ForeignKey("dbo.Razas", t => t.razaFK, cascadeDelete: true)
                .Index(t => t.razaFK)
                .Index(t => t.propietario);
            
            CreateTable(
                "dbo.Propietarios",
                c => new
                    {
                        cedula = c.Long(nullable: false),
                        nombre = c.String(nullable: false),
                        apellido = c.String(nullable: false),
                        celular = c.String(nullable: false),
                        correo = c.String(),
                    })
                .PrimaryKey(t => t.cedula);
            
            CreateTable(
                "dbo.Razas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 30),
                        idEspecie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Especies", t => t.idEspecie, cascadeDelete: true)
                .Index(t => t.idEspecie);
            
            CreateTable(
                "dbo.Especies",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Monitoreos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        historia = c.String(maxLength: 128),
                        peso = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historia)
                .Index(t => t.historia);
            
            CreateTable(
                "dbo.MonitoreoPacientes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha_hora = c.DateTime(nullable: false),
                        temperatura = c.Double(nullable: false),
                        pulso = c.Double(nullable: false),
                        trc = c.String(),
                        fr = c.Double(nullable: false),
                        peritaltismo = c.String(),
                        mucosas = c.String(),
                        observacion = c.String(),
                        monitoreoFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Monitoreos", t => t.monitoreoFk, cascadeDelete: true)
                .Index(t => t.monitoreoFk);
            
            CreateTable(
                "dbo.PlanTerapeuticoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fecha_hora = c.DateTime(nullable: false),
                        tipo = c.Int(nullable: false),
                        nombre = c.String(),
                        observacion = c.String(),
                        monitoreoFk = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Monitoreos", t => t.monitoreoFk, cascadeDelete: true)
                .Index(t => t.monitoreoFk);
            
            CreateTable(
                "dbo.Auto_Necropsia",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Diagnostico = c.String(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        historia = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historia)
                .Index(t => t.historia);
            
            CreateTable(
                "dbo.Remisions",
                c => new
                    {
                        remisionID = c.Int(nullable: false, identity: true),
                        fechaRemision = c.DateTime(nullable: false),
                        historiaFK = c.String(maxLength: 128),
                        veterinarioID = c.String(maxLength: 128),
                        region = c.String(nullable: false),
                        vista = c.String(nullable: false),
                        diagnostico = c.String(nullable: false),
                        ecografia = c.String(nullable: false),
                        evaluacion = c.String(nullable: false),
                        resultado = c.String(nullable: false),
                        observacion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.remisionID)
                .ForeignKey("dbo.HistoriaClinicas", t => t.historiaFK)
                .ForeignKey("dbo.Veterinarios", t => t.veterinarioID)
                .Index(t => t.historiaFK)
                .Index(t => t.veterinarioID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SolicitudExamen",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        numeroRecibo = c.Int(nullable: false),
                        mascota = c.String(maxLength: 128),
                        muestraRemitida = c.String(nullable: false),
                        examenSolicitado = c.String(nullable: false),
                        diagnosticoPresuntivo = c.String(nullable: false),
                        veterinarioFK = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Mascotas", t => t.mascota)
                .ForeignKey("dbo.Veterinarios", t => t.veterinarioFK, cascadeDelete: true)
                .Index(t => t.mascota)
                .Index(t => t.veterinarioFK);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SolicitudExamen", "veterinarioFK", "dbo.Veterinarios");
            DropForeignKey("dbo.SolicitudExamen", "mascota", "dbo.Mascotas");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Auto_Cirugia", "historia", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.Remisions", "veterinarioID", "dbo.Veterinarios");
            DropForeignKey("dbo.Remisions", "historiaFK", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.Auto_Necropsia", "historia", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.PlanTerapeuticoes", "monitoreoFk", "dbo.Monitoreos");
            DropForeignKey("dbo.MonitoreoPacientes", "monitoreoFk", "dbo.Monitoreos");
            DropForeignKey("dbo.Monitoreos", "historia", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.HistoriaClinicas", "id", "dbo.Mascotas");
            DropForeignKey("dbo.Mascotas", "razaFK", "dbo.Razas");
            DropForeignKey("dbo.Razas", "idEspecie", "dbo.Especies");
            DropForeignKey("dbo.Mascotas", "propietario", "dbo.Propietarios");
            DropForeignKey("dbo.GestionVacunacions", "historiaFK", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.Formulae", "veterinarioD", "dbo.Veterinarios");
            DropForeignKey("dbo.Medicamentoes", "Formula_formulaID", "dbo.Formulae");
            DropForeignKey("dbo.Formulae", "historiaFK", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.Auto_Eutanasia", "historia", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.Controls", "veterinarioFK", "dbo.Veterinarios");
            DropForeignKey("dbo.Controls", "historia", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.Auto_Consentimiento", "historia", "dbo.HistoriaClinicas");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SolicitudExamen", new[] { "veterinarioFK" });
            DropIndex("dbo.SolicitudExamen", new[] { "mascota" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Remisions", new[] { "veterinarioID" });
            DropIndex("dbo.Remisions", new[] { "historiaFK" });
            DropIndex("dbo.Auto_Necropsia", new[] { "historia" });
            DropIndex("dbo.PlanTerapeuticoes", new[] { "monitoreoFk" });
            DropIndex("dbo.MonitoreoPacientes", new[] { "monitoreoFk" });
            DropIndex("dbo.Monitoreos", new[] { "historia" });
            DropIndex("dbo.Razas", new[] { "idEspecie" });
            DropIndex("dbo.Mascotas", new[] { "propietario" });
            DropIndex("dbo.Mascotas", new[] { "razaFK" });
            DropIndex("dbo.GestionVacunacions", new[] { "historiaFK" });
            DropIndex("dbo.Medicamentoes", new[] { "Formula_formulaID" });
            DropIndex("dbo.Formulae", new[] { "veterinarioD" });
            DropIndex("dbo.Formulae", new[] { "historiaFK" });
            DropIndex("dbo.Auto_Eutanasia", new[] { "historia" });
            DropIndex("dbo.Controls", new[] { "veterinarioFK" });
            DropIndex("dbo.Controls", new[] { "historia" });
            DropIndex("dbo.Auto_Consentimiento", new[] { "historia" });
            DropIndex("dbo.HistoriaClinicas", new[] { "id" });
            DropIndex("dbo.Auto_Cirugia", new[] { "historia" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SolicitudExamen");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Remisions");
            DropTable("dbo.Auto_Necropsia");
            DropTable("dbo.PlanTerapeuticoes");
            DropTable("dbo.MonitoreoPacientes");
            DropTable("dbo.Monitoreos");
            DropTable("dbo.Especies");
            DropTable("dbo.Razas");
            DropTable("dbo.Propietarios");
            DropTable("dbo.Mascotas");
            DropTable("dbo.GestionVacunacions");
            DropTable("dbo.Medicamentoes");
            DropTable("dbo.Formulae");
            DropTable("dbo.Auto_Eutanasia");
            DropTable("dbo.Veterinarios");
            DropTable("dbo.Controls");
            DropTable("dbo.Auto_Consentimiento");
            DropTable("dbo.HistoriaClinicas");
            DropTable("dbo.Auto_Cirugia");
            DropTable("dbo.Administradors");
        }
    }
}
