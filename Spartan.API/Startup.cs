using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Http;

using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;



[assembly: OwinStartup(typeof(Spartan.API.Startup))]

namespace Spartan.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            /*
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);    
            */    
                
       }
    }
}
