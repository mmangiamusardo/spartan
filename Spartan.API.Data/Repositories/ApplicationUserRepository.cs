using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Spartan.Domain;
using Spartan.Data.Infrastructure;

namespace Spartan.Data
{
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(IDbFactory dbfactory) : base(dbfactory) { }
    }

    public interface IApplicationUserRepository : IRepository<ApplicationUser> { }
}
