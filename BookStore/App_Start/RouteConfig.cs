using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;
using BookStore.RouteConstraint;

namespace BookStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Esse código seria responsável por adicionar constraints no route. Ver TesteController.MinhaAction4
            //DefaultInlineConstraintResolver constraintsResolver = new DefaultInlineConstraintResolver();
            //constraintsResolver.ConstraintMap.Add("values", typeof(ValuesConstraint));

            //routes.MapMvcAttributeRoutes(constraintsResolver);

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
