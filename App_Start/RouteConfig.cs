using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HealthCare
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Retrieve",
                url: "Home/RetrieveEmployee/{*values}",
                defaults: new { controller = "Home", action = "RetrieveEmployee" }
            );

            routes.MapRoute(
                name: "Update",
                url: "Home/UpdatePlan/{*values}",
                defaults: new { controller = "Home", action = "UpdatePlan" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
