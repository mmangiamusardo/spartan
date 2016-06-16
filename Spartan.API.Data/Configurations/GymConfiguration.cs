using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartan.Domain;

namespace Spartan.Data.Configurations
{
    public class GymConfiguration : EntityTypeConfiguration<Gym>
    {
        public GymConfiguration()
        {
            ToTable("Gyms");
        }
    }
}
