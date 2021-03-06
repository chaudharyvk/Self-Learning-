﻿using DomainDrivenDesign.Core.Interfaces;
using DomainDrivenDesign.ShareKernal.FrontDesk.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Core.Model
{
    public class Address : Entity<int>
    {
        //[Key()]
        //public int ID { get; set; }

        //public virtual int CustomerID { get;protected set; }

        [Display(Name = "Address")]
        public string Address1 { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public int PIN { get; set; }

        //[ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }
}
