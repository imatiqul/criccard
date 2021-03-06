﻿using Exact.Criccard.Domain.Interfaces;
using StructureMap;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace Exact.Criccard.CricAPI.Configuration
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}"
            );
            var corsSites = System.Configuration.ConfigurationManager.AppSettings["EnabledCORSSites"].ToString();
            var cors = new System.Web.Http.Cors.EnableCorsAttribute(corsSites, "*", "*");

            config.EnableCors();
        }
    }
}