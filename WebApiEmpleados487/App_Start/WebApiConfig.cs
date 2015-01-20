using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using WebApiEmpleados487.Extensiones;

namespace WebApiEmpleados487
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // Web API configuration and services
            config.MessageHandlers.Add(new LogHandler());
            config.MessageHandlers.Add(new AuthHandler());

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling=
                PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            
            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
