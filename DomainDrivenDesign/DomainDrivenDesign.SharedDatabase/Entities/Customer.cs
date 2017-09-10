using DomainDrivenDesign.ShareKernal.FrontDesk.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.SharedDatabase.Entities
{
    public class Customer : Entity<int>
    {
             
        public string FirstName { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Address Addresses { get; set; }

       
    }
}
