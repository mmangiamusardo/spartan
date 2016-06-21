using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartan.Domain
{
    public class Gym : SpartanBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GymType GymType { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }

        public string WebUrl { get; set; }

        public string OpeningHour { get; set; }
        public string ClosingHour { get; set; }

        public string AppUserId { get; set; }
        public virtual ApplicationUser AppUser { get; set; }

    }

    public class GymType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
}
