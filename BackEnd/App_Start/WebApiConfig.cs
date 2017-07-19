using Newtonsoft.Json;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BackEnd
{
    public static class WebApiConfig
    {
        public static void Register(IAppBuilder app, HttpConfiguration config)
        {
           
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling = ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            var cors = new EnableCorsAttribute("*", "*", "*") { SupportsCredentials = true };
            config.EnableCors(cors);
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //ar reikia??
            //config.Routes.MapHttpRoute(
            //    name: "SmsRoute",
            //    routeTemplate: "api/{controller}/{phone}/{message}",
            //    defaults: new { phone = RouteParameter.Optional, message = RouteParameter.Optional }
            //);

            app.UseWebApi(config);

        }
    }
}
