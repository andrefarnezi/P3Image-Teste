using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace P3Image_Teste.Publico
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{slugCategoria}/{slugSubCategoria}",
                defaults: new { controller = "FormP3Image", action = "Formulario", slugCategoria = UrlParameter.Optional, slugSubCategoria = UrlParameter.Optional }
            );
        }
    }
}