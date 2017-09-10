using DomainDrivenDesign.Core.Interfaces;
using DomainDrivenDesign.ShareKernal;
using DomainDrivenDesign.ShareKernal.FrontDesk.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Core.Model
{
    public class Customer : Entity<int>
    {
        //[Display(Name="Customer ID")]
        //[Key()]
        //public  int ID  { get;set;}

        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
        
        public  virtual Address Addresses { get; set; }

        public virtual TrackingState TrackingState { get; set; }
    }
}
