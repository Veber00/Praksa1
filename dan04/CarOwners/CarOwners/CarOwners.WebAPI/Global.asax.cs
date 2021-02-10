using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using CarOwners.Model;
using CarOwners.Repository;
using CarOwners.Service;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace CarOwners.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IContainer container { get; set; }
        protected void Application_Start(object sender, EventArgs e)
        {

            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();

            builder.RegisterModule<CarOwnersRepositoryModule>();
            builder.RegisterModule<CarOwnersServiceModule>();
            builder.RegisterModule<CarOwnersModelModule>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;

        }
    }
}
