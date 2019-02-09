using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PatientDemographicDetails.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.Routes.MapHttpRoute(name: "Default", routeTemplate: "api/{controller}");
            //Enabled cors
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            ////EnableCorsAttribute cors = new EnableCorsAttribute("http://localhost", "*", "*");
            config.EnableCors(cors);
            //config.EnableSystemDiagnosticsTracing();
        }
    }
}
