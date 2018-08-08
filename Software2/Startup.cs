using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Software2.Models;

[assembly: OwinStartupAttribute(typeof(Software2.Startup))]
namespace Software2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        public void createRolesandUsers()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(
                   new RoleStore<IdentityRole>(db)
                   );

            if (!roleManager.RoleExists("Admin"))
            {
                var resultado = roleManager.Create(new IdentityRole("Admin"));
            }
            if (!roleManager.RoleExists("Practicante"))
            {
                var resultado = roleManager.Create(new IdentityRole("Practicante"));
            }
            if (!roleManager.RoleExists("Medico"))
            {
                var resultado = roleManager.Create(new IdentityRole("Medico"));
            }
        }
    }
}
