using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using NLog;
using NLog.LayoutRenderers;

using Autofac;
using Autofac.Integration.WebApi;

using Spartan.Core;
using Spartan.Service;
using Spartan.Data.Repositories;
using Spartan.Data.Infrastructure;

namespace Spartan.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Autofac configuration
            var builder = new ContainerBuilder();

            // REGISTER DEPENDENCIES
            //builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            //builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            //builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            //builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            //builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            //builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();

            builder.RegisterApiControllers(typeof(GymsController).Assembly);

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(GymRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(GymService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);



            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "PagedItemsApiWithParams",
               routeTemplate: "api/{controller}/page/{pageIndex}/{pageSize}",
               defaults: new
               {
                   action = "GetPaged"
               }
            );

            config.Routes.MapHttpRoute(
               name: "PagedItemsApiNoParams",
               routeTemplate: "api/{controller}/page",
               defaults: new
               {
                   action = "GetPaged"
               }
            );


            // Logger Handler
            config.MessageHandlers.Add(new LoggerDelegatingHandler());

            // Exception Handler
            config.Services.Replace(typeof(IExceptionHandler), new GeneralExceptionHandler());

            // Remove default xml formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

        }
    }
}
