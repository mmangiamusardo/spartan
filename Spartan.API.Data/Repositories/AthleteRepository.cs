using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartan.Domain;
using Spartan.Data.Infrastructure;


namespace Spartan.Data.Repositories
{
    public class AthleteRepository : RepositoryBase<Athlete>, IAthleteRepository
    {
        public AthleteRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IAthleteRepository : IRepository<Athlete>
    {

    }
}
