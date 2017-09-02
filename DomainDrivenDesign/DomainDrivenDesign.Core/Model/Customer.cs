using DomainDrivenDesign.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Core.Model
{
    public class Customer : IEntity
    {
        [Display(Name="Customer ID")]
        public int ID  { get;set;}

        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
