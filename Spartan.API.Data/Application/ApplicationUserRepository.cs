using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Spartan.Domain;
using Spartan.Data.Infrastructure;
using System.Linq.Expressions;

namespace Spartan.Data.Repositories
{
    public class ApplicationUserRepository : RepositoryBase<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationUserStore AppUsrStore;

        public ApplicationUserRepository(IDbFactory dbfactory) : base(dbfactory)
        {
            //AppUsrStore = new ApplicationUserStore(dbfactory);
        }

        //public override void Add(ApplicationUser user)
        //{
        //    appUsrStore.CreateAsync(user);
        //    //base.Add(entity);
        //}
    }


    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {

    }
}
