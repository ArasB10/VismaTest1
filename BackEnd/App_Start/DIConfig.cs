using Autofac;
using Autofac.Integration.WebApi;
using BackEnd.Controllers;
using MyLibrary;
using MyLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace BackEnd.App_Start
{
    public class DIConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ContactsAppDbEntities>().InstancePerRequest();

            builder.RegisterType<DbGetter>().As<IDataGetter>().InstancePerRequest();
            //builder.RegisterType<>().As<IRepository<Message>>().InstancePerRequest();

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}