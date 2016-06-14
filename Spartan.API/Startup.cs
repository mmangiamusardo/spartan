using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Http;

using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;


//Assembly attribute which class to fire at start-up
[assembly: OwinStartup(typeof(Spartan.API.Startup))]

namespace Spartan.API
{
    public partial class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app">app parameter is supplied by the host at run-time</param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            /*
            //The HttpConfiguration object is used to configure API routes
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);    
            */

        }
    }
}
