namespace Software2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Formulae", "mascotaID", "dbo.Mascotas");
            DropForeignKey("dbo.GestionVacunacions", "mascotaID", "dbo.Mascotas");
            DropForeignKey("dbo.Remisions", "mascotaID", "dbo.Mascotas");
            DropIndex("dbo.Formulae", new[] { "mascotaID" });
            DropIndex("dbo.GestionVacunacions", new[] { "mascotaID" });
            DropIndex("dbo.Remisions", new[] { "mascotaID" });
            AddColumn("dbo.Formulae", "historiaFK", c => c.String(maxLength: 128));
            AddColumn("dbo.GestionVacunacions", "historiaFK", c => c.String(maxLength: 128));
            AddColumn("dbo.Remisions", "historiaFK", c => c.String(maxLength: 128));
            CreateIndex("dbo.Formulae", "historiaFK");
            CreateIndex("dbo.GestionVacunacions", "historiaFK");
            CreateIndex("dbo.Remisions", "historiaFK");
            AddForeignKey("dbo.Formulae", "historiaFK", "dbo.HistoriaClinicas", "id");
            AddForeignKey("dbo.GestionVacunacions", "historiaFK", "dbo.HistoriaClinicas", "id");
            AddForeignKey("dbo.Remisions", "historiaFK", "dbo.HistoriaClinicas", "id");
            DropColumn("dbo.Formulae", "mascotaID");
            DropColumn("dbo.GestionVacunacions", "mascotaID");
            DropColumn("dbo.Remisions", "mascotaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Remisions", "mascotaID", c => c.String(maxLength: 128));
            AddColumn("dbo.GestionVacunacions", "mascotaID", c => c.String(maxLength: 128));
            AddColumn("dbo.Formulae", "mascotaID", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Remisions", "historiaFK", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.GestionVacunacions", "historiaFK", "dbo.HistoriaClinicas");
            DropForeignKey("dbo.Formulae", "historiaFK", "dbo.HistoriaClinicas");
            DropIndex("dbo.Remisions", new[] { "historiaFK" });
            DropIndex("dbo.GestionVacunacions", new[] { "historiaFK" });
            DropIndex("dbo.Formulae", new[] { "historiaFK" });
            DropColumn("dbo.Remisions", "historiaFK");
            DropColumn("dbo.GestionVacunacions", "historiaFK");
            DropColumn("dbo.Formulae", "historiaFK");
            CreateIndex("dbo.Remisions", "mascotaID");
            CreateIndex("dbo.GestionVacunacions", "mascotaID");
            CreateIndex("dbo.Formulae", "mascotaID");
            AddForeignKey("dbo.Remisions", "mascotaID", "dbo.Mascotas", "id");
            AddForeignKey("dbo.GestionVacunacions", "mascotaID", "dbo.Mascotas", "id");
            AddForeignKey("dbo.Formulae", "mascotaID", "dbo.Mascotas", "id");
        }
    }
}
