using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoolBlue.PointofSale.UI.Models
{
   

    public class ProductViewModel
    {

        public int Id { get; set; }
 
        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}