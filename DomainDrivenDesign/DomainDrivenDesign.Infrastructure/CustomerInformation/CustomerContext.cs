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

        //todo
       
    }
}
