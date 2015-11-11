using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartan.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        SpartanEntities dbContext;

        public SpartanEntities Init()
        {
            return dbContext ?? (dbContext = new SpartanEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
