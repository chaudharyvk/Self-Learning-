using CoolBlue.PointofSale.SharedKernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Core.Model.Events
{
    public class CreateCustomerEvent : IDomainEvent
    {
        public CreateCustomerEvent()
        {
            this.Id = Guid.NewGuid();
            DateTimeEventOccurred = DateTime.Now;
        }

        public CreateCustomerEvent(Customer customer) : this()
        {
            CustomerCreated = customer;
        }

        public DateTime DateTimeEventOccurred { get;private set;}

        public Guid Id { get; private set;}

        public Customer CustomerCreated { get; private set; }
    }
}
