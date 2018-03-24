using CoolBlue.PointofSale.SharedKernal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Database.Entities
{
    public class Customer : Entity<int>
    {
       
        public string UserId { get; set; }

        public string password { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Address Addresses { get; set; }

        public virtual Order Orders { get; set; }
    }
}
