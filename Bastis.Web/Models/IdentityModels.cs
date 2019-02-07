using Bastis.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Bastis.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }

        public virtual ICollection<CustomPermission> CustomPermissions { get; set; }       
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }
        public string Description { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Agent> Agents { get; set; }

        //public DbSet<AspNetRoles> AspNetRoles { get; set; }
        //public DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public DbSet<AspNetUsers> AspNetUsers { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<CustomPermission> CustomPermissions { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<State> States { get; set; }       

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Bastis.Models.ApplicationRole> IdentityRoles { get; set; }
    }
}