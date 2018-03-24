using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.SharedKernal.Interfaces
{
   public  interface IDomainEvent
    {
        DateTime  DateTimeEventOccurred { get; }
    }
}
