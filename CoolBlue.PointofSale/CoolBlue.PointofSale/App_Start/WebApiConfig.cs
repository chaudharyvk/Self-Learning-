using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Unity;
using CoolBlue.PointofSale.Core.Interfaces;
using CoolBlue.PointofSale.Infrastructure;
using CoolBlue.PointofSale.Infrastructure.Product.Data;
using CoolBlue.PointofSale.Infrastructure.Customer.Data.Repositories;
using CoolBlue.PointofSale.Infrastructure.Order.Data.Repositories;

namespace CoolBlue.PointofSale
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<PointofSaleContext>();
            container.RegisterType<IProductRepository, ProductRepositories>();
            container.RegisterType<ICustomerRepository, CustomerRepositories>();
            container.RegisterType<IOrderRepository, OrderRepositories>();
            config.DependencyResolver = new Controllers.UnityResolver(container);

        }
    }
}
