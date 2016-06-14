using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartan.Domain
{
    public class Permission
    {
        public int Id { get; set; }

        public string Descr { get; set; }

        public virtual List<ApplicationRole> Roles { get; set; }
    }
}
