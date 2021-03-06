﻿using CoolBlue.PointofSale.Database.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Database.Context
{
    public class OrderDBContext : DbContext
    { 
        public OrderDBContext() : base("name=CoolBluePointofSale")
        {

        }


        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
            
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasRequired(c => c.Customer).WithRequiredDependent(x => x.Addresses).Map(m => m.MapKey("CustomerID"));
            //modelBuilder.Entity<Order>().HasOptional(c => c.Customer).WithOptionalDependent(x => x.Orders).Map(m => m.MapKey("CustomerID"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
