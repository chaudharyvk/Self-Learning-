using CoolBlue.PointofSale.SharedKernal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Core.Model
{
    public class Order : Entity<int>
    {
        [Required]
        public string Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
