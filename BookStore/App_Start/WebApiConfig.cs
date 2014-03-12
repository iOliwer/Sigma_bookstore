using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BookStore
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ByIdApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                constraints: new { id = @"^B[\d]+$" } //Matchar: Stort B i början av en sträng och en siffra i slutet. Detta för att matcha exempelvis id:et "B10" 
            );

            config.Routes.MapHttpRoute(
                name: "SearchByTerm",
                routeTemplate: "api/{controller}/{searchterm}",
                defaults: new { searchterm = RouteParameter.Optional }
            );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

        }
    }
}
