using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartan.Domain
{
    public class Attendee
    {
        public Athlete Athlete { get; set; }

        public string AppUserId { get; set; }
        public virtual ApplicationUser AppUser { get; set; }

        public List<Event> Events { get; set; } 
    }
}
