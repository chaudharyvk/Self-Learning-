using CoolBlue.PointofSale.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Core.Interfaces
{
   public interface IOrderRepository
    {
        int PlaceOrder(Customer customer, List<Product> product);
      
        Task<int> OrderSaveChangesAsync();

        IQueryable<Order> GetOrderDetails(int id);
    }
}
