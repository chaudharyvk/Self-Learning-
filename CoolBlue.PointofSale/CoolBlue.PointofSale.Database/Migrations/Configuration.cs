namespace CoolBlue.PointofSale.Database.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CoolBlue.PointofSale.Database.Context.OrderDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CoolBlue.PointofSale.Database.Context.OrderDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            Address address1 = new Address() { FirstName = "Bob", LastName = "Martin", PhoneNumber = "436991736699", City = "Rotterdon", Country = "Netherland", PinCode = 1232 };

            Address address2 = new Address() { FirstName = "Bob", LastName = "Martin", PhoneNumber = "436991736699", City = "Rotterdon", Country = "Netherland", PinCode = 1232 };

            Address address3 = new Address() { FirstName = "Bob", LastName = "Martin", PhoneNumber = "436991736699", City = "Rotterdon", Country = "Netherland", PinCode = 1232 };
            
            Address address4 = new Address() { FirstName = "Bob", LastName = "Martin", PhoneNumber = "436991736699", City = "Rotterdon", Country = "Netherland", PinCode = 1232 };

            var customers = new List<Customer>()
            {
                new Customer() { UserId = "Bob", password = "bob123",Addresses= address1 },
                new Customer() { UserId = "Bob1", password = "bob123", Addresses = address2 },
                new Customer() { UserId = "Bob2", password = "bob123", Addresses = address3 },
                new Customer() { UserId = "Bob3", password = "bob123", Addresses = address4 }
            };

            customers.ForEach(p => context.Customers.Add(p));

            context.SaveChanges();

            var products = new List<Product>()
            {
                new Product() { Name = "Apple IPhone 7", Price = 111.39M },
                new Product() { Name = "Apple Iphone 4S", Price = 1116.99M },
                new Product() { Name = "Apple Iphoen 6", Price = 611.99M,}
            };

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();

            //var findCustomerbob = context.Customers.First(x => x.UserId == "Bob1");

            //if (findCustomerbob != null)
            //{
                var order = new Order() { Customer = "Bob" };
                var od = new List<OrderDetail>()
                    {
                        new OrderDetail() { Product = products[0], Quantity = 2, Order = order},
                        new OrderDetail() { Product = products[1], Quantity = 4, Order = order }
                   };
                context.Orders.Add(order);

            //}
            context.SaveChanges();



          
        }
    }
}
