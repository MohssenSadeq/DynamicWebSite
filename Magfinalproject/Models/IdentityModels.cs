using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Magfinalproject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {        [Required]
        [Display(Name = "أسم المستخدم")]

        public string nikname { get; set; }
        [Display(Name = "نوع المستخدم")]

        public string UserType { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
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

        public System.Data.Entity.DbSet<Magfinalproject.Models.Categorie> Categories { get; set; }


        public System.Data.Entity.DbSet<Magfinalproject.Models.cardinfo> cardinfoes { get; set; }

        public System.Data.Entity.DbSet<Magfinalproject.Models.college> colleges { get; set; }

        public System.Data.Entity.DbSet<Magfinalproject.Models.staff> staffs { get; set; }

        public System.Data.Entity.DbSet<Magfinalproject.Models.department> departments { get; set; }

  


        public System.Data.Entity.DbSet<Magfinalproject.Models.Carsual> Carsuals { get; set; }

        public System.Data.Entity.DbSet<Magfinalproject.Models.Request_to_edit> Request_to_edit { get; set; }
        public System.Data.Entity.DbSet<Magfinalproject.Models.Thesis> Theses { get; set; }

        public System.Data.Entity.DbSet<Magfinalproject.Models.center> centers { get; set; }

        public System.Data.Entity.DbSet<Magfinalproject.Models.footer> footers { get; set; }

        public System.Data.Entity.DbSet<Magfinalproject.Models.social> socials { get; set; }

        public System.Data.Entity.DbSet<Magfinalproject.Models.contacts> contacts { get; set; }

        public System.Data.Entity.DbSet<Magfinalproject.Models.ask> asks { get; set; }

        public System.Data.Entity.DbSet<Magfinalproject.Models.agent> agents { get; set; }

    }
}