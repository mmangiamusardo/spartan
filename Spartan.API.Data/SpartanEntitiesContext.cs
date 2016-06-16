using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using Spartan.Domain;
using Spartan.Data.Configurations;

namespace Spartan.Data
{
    public class SpartanEntitiesContext : 
        IdentityDbContext<ApplicationUser, 
            ApplicationRole, 
            int, 
            ApplicationUserLogin, 
            ApplicationUserRole, 
            ApplicationUserClaim>
    {
        public SpartanEntitiesContext()
            : base("SpartanEntitiesContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Gym> Gyms { get; set; }
        public virtual DbSet<Class> Classes { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder mb)
        {

            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //mb.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            mb.Entity<ApplicationUser>().HasKey(u => u.Id);
            mb.Entity<ApplicationRole>().HasKey(r => r.Id);
            mb.Entity<ApplicationUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            mb.Entity<ApplicationUserLogin>().HasKey(l => l.UserId);


            //mb.Configurations.Add(new GymConfiguration());
        }

        public static SpartanEntitiesContext Create()
        {
            return new SpartanEntitiesContext();
        }
    }
}
