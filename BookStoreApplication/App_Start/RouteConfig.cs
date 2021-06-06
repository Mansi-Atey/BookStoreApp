using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStoreApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Resgister",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Book",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Book", action = "GetAllBooks", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AddCart",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Cart", action = "AddToCart", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "RemoveCart",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Cart", action = "DeleteCartByCartId", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Cart",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Cart", action = "GetAllCart", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "AddCustomer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CustomerDetails", action = "AddCustomerDetails", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Customer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CustomerDetails", action = "GellAllCustomerDetails", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "WishList",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "WishList", action = "AddToWishList", id = UrlParameter.Optional }
           );
        }
    }
}
