using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainDrivenDesign.Core.Model;

namespace DomainDrivenDesign.Infrastructure.CustomerInformation
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("name=CustomerInformation")
        {
                
        }


        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Customer>.Addresses
            modelBuilder.Entity<Address>().HasRequired(c => c.Customer).WithRequiredDependent(x=>x.Addresses).Map(m=>m.MapKey("CustomerID"));
            modelBuilder.Entity<Customer>().Ignore(x => x.TrackingState);
            base.OnModelCreating(modelBuilder);
        }

        //todo

    }
}
