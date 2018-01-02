using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using GymClass_v0._2.Utility;

namespace GymClass_v0._2.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
        [Required(ErrorMessage = "Please enter your first name.")]
        [DisplayName("First Name")]
        [DisplayFormat(NullDisplayText = "Undefined")]
        [StringLength(100)]
        [MaxWords(2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [DisplayName("Last Name")]
        [DisplayFormat(NullDisplayText = "Undefined")]
        [StringLength(100)]
        [MaxWords(2)]
        public string LastName { get; set; }
        
        public string FullName { get { return FirstName + " " + LastName; } }

        [Column(TypeName = "datetime2")]
        public DateTime TimeOfRegistration { get; set; }

        public virtual ICollection<GymClass> AttendedClasses { get; set; }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<GymClass> GymClasses { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<GymClass_v0._2.ViewModel.Members> Members { get; set; }
    }
}