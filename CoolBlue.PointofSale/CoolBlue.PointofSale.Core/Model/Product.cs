using CoolBlue.PointofSale.SharedKernal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Core.Model
{
   public class Product : Entity<int>
    {
         
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        


    }
}
