using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartan.Domain;
using Spartan.Data.Infrastructure;

namespace Spartan.Data.Repositories
{
    public class GymRepository : RepositoryBase<Gym>, IGymRepository
    {
        public GymRepository(IDbFactory dbfactory) : base(dbfactory) { }
    }

    public interface IGymRepository : IRepository<Gym> { }
}
