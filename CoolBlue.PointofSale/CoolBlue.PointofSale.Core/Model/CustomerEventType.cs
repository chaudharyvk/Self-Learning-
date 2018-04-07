using CoolBlue.PointofSale.SharedKernal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Core.Model
{
    public class CustomerEventType : ILookup
    {
        public string Name { get; }

        public string Description { get; }

        public int Id { get; }
    }
}
