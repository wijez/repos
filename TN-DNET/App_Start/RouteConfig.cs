using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TN_DNET
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Hello", action = "Index", id = UrlParameter.Optional }
           );

           // routes.MapRoute(
           //    name: "Login",
           //    url: "login",
           //    defaults: new { controller = "Hello", action = "Login"}
           //);

            //  routes.MapRoute(
            //    name: "Login",
            //    url: "Hello/{controller}/{action}",
            //    defaults: new { controller = "Account", action = "Index"}
            //);
        }
    }
}
