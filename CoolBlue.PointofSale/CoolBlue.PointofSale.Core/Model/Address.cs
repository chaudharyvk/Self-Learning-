using CoolBlue.PointofSale.SharedKernal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Core.Model
{
    
    [Table("Address",Schema ="dbo")]
    public class Address : Entity<int>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        //public string EmailAddress { get; set;}

        //public string PhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public virtual Customer Customer { get; set; }

      
    }
}
