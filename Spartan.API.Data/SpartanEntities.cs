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
    public class SpartanEntities : IdentityDbContext<AppUser>
    {
        public SpartanEntities()
            : base("SpartanEntities")
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Configurations.Add(new GymConfiguration());
        }

        public static SpartanEntities Create()
        {
            return new SpartanEntities();
        }
    }
}
