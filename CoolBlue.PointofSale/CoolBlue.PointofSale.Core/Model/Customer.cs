using CoolBlue.PointofSale.Core.Model.Events;
using CoolBlue.PointofSale.SharedKernal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Core.Model
{
    public class Customer : Entity<int>
    {
   
        public string UserId { get; set; }

        public string Password { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Address Addresses { get; set; }

        public virtual Order Orders { get; set; }


        public static Customer CreateCustomer(string userid,string password, Address address)
        {
            Customer customer = new Customer()
            {
                UserId = userid,
                Password = password
            };

            customer.Addresses = new Address();
            customer.Addresses = address;
            CreateCustomerEvent createCustomerEvent = new CreateCustomerEvent(customer);
            DomainEvents.Raise(createCustomerEvent);
            return customer;
        }
    }
}
