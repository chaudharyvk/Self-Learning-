using CoolBlue.PointofSale.SharedKernal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Core.Model
{
  public  class OrderDetail : Entity<int>
    {
       
        public virtual int Quantity { get; protected set; }
        public virtual int OrderId { get; protected set; }
        public virtual int ProductId { get; protected set; }

        // Navigation properties
        public virtual Product Product { get; protected set; }
        public virtual Order Order { get; protected set; }
    }
}
