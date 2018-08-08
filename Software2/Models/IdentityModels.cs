using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Software2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Software2.Models.Especie> Especies { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Raza> Razas { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Propietario> Propietarios { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Mascota> Mascotas { get; set; }
    
        

        public System.Data.Entity.DbSet<Software2.Models.SolicitudExamen> SolicitudExamen { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.GestionVacunacion> GestionVacunacions { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Medicamento> Medicamentoes { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Formula> Formulae { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Control> Controls { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.HistoriaClinica> HistoriaClinicas { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Monitoreo> Monitoreos { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.MonitoreoPacientes> MonitoreoPacientes { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.PlanTerapeutico> PlanTerapeuticoes { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Administrador> Administradors { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Veterinario> Veterinarios { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Remision> Remisions { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Auto_Cirugia> Auto_Cirugia { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Auto_Necropsia> Auto_Necropsia { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Auto_Eutanasia> Auto_Eutanasia { get; set; }

        public System.Data.Entity.DbSet<Software2.Models.Auto_Consentimiento> Auto_Consentimiento { get; set; }
    }
}