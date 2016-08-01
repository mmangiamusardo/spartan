using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;

using Spartan.Domain;
using Spartan.Data.Infrastructure;

namespace Spartan.Data
{
    public class ApplicationUserStore : UserStore<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>, IUserStore<ApplicationUser, int>
    {

        //public ApplicationUserStore(IdentityDbContext context) : base(context)
        //{
        //    ;
        //}


        //public applicationuserstore(idbfactory dbfactory) : base(dbfactory.init())
        //{
        //    ;
        //}

        public ApplicationUserStore(SpartanEntitiesContext context) : base(context)
        {
            ;
        }
    }
}
