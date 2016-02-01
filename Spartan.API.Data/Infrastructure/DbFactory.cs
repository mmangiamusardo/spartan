using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartan.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        SpartanEntitiesContext dbContext;

        public SpartanEntitiesContext Init()
        {
            return dbContext ?? (dbContext = new SpartanEntitiesContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
