using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartan.Domain
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Class Class { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Frequency { get; set; }
    }
}
