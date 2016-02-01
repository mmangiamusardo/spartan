using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace Spartan.Core
{
    public class GeneralExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new GeneralErrorResult
            {
                Request = context.ExceptionContext.Request,
                Content = "An error has occurred on the server. Please contact support!"
            };
        }
    }
}