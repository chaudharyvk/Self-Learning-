using CoolBlue.PointofSale.Core.Model.Events;
using CoolBlue.PointofSale.SharedKernal;
using CoolBlue.PointofSale.SharedKernal.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Core.Model
{
    [Table("Customer", Schema = "dbo")]
    public class Customer : Entity<int>, IAudit
    {
   
        public virtual string UserId { get; set; }

        public virtual string Password { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual int? UpdatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }

        //public virtual Order Orders { get; set; }


        public static Customer CreateCustomer(string userid,string password, ICollection<Address> addresses)
        {
            Customer customer = new Customer()
            {
                UserId = userid,
                Password = password
                
            };

            customer.SetAudit();
            customer.Addresses = new List<Address>();
        
            foreach(var address in addresses)
            {
                address.SetAudit();
            }
            customer.Addresses = addresses;
               
           // CreateCustomerEvent createCustomerEvent = new CreateCustomerEvent(customer);
           // DomainEvents.Raise(createCustomerEvent);
            return customer;
        }


        public virtual void EditCustomer(int id,string userid, string password, Address address)
        {
            this.UserId = userid;
            this.Password = password;
            //this.Addresses = address;
            // CreateCustomerEvent createCustomerEvent = new CreateCustomerEvent(customer);
            // DomainEvents.Raise(createCustomerEvent);           
        }


        private void SetAudit()
        {
            this.CreatedDate = DateTime.Today.Date;
            this.CreatedBy = 11;       
        }        
    }
}
