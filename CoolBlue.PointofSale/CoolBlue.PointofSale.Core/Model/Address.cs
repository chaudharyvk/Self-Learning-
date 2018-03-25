using CoolBlue.PointofSale.SharedKernal;
using CoolBlue.PointofSale.SharedKernal.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Core.Model
{
    
    [Table("Address",Schema ="dbo")]
    public class Address : Entity<int>, IAudit
    {
        [ForeignKey("Customer")]
        [NotMapped]
        public virtual int CustomerId { get; protected set; }
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string Address1 { get; set; }
        public virtual string Address2 { get; set; }

        public virtual string Country { get; set; }

        public virtual string City { get; set; }

        public int PostalCode { get; set; }

        //public string EmailAddress { get; set;}

        //public string PhoneNumber { get; set; }

        public int MobileNumber { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual int CreatedBy { get; set; }
        public virtual int? UpdatedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? UpdatedDate { get; set; }


        public void SetAudit()
        {
            this.CreatedDate = DateTime.Today.Date;
            this.CreatedBy = 11;
        }
    }
}
