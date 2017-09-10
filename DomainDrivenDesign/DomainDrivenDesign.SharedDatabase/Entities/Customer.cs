﻿using DomainDrivenDesign.ShareKernal.FrontDesk.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.SharedDatabase.Entities
{
    public class Customer : Entity<int>
    {
            
        public string FirstName { get; set; }

       
        public byte[] RowVersion { get; set; }

        public virtual Address Addresses { get; set; }

       
    }
}
