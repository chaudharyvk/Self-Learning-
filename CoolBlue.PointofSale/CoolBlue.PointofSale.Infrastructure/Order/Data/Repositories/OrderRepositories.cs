using CoolBlue.PointofSale.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolBlue.PointofSale.Core.Model;
using System.Data.Entity;

namespace CoolBlue.PointofSale.Infrastructure.Order.Data.Repositories
{

    //todo Idisposable implement
    public class OrderRepositories : IOrderRepository
    {

        PointofSaleContext _OrderContext;
        public OrderRepositories(PointofSaleContext context)
        {
            this._OrderContext = context;
        }

        public int PlaceOrder(Core.Model.Customer customer, List<Core.Model.Product> product)
        {

            //List<OrderDetail> orderDetails = new List<OrderDetail>()
            //{
            //   new OrderDetail() {ProductId=product.Id,Quantity=3 }
            //};

            var order = new Core.Model.Order()
            {
                Customer = customer.UserId,
                OrderDetails = (from item in product
                                select new OrderDetail() { ProductId = item.Id, Quantity = item.Quantity }).ToList()
            };

            this._OrderContext.Orders.Add(order);
            return this._OrderContext.SaveChanges();


        }



        public Task<int> OrderSaveChangesAsync()
        {
            return this._OrderContext.SaveChangesAsync();
        }

        public IQueryable<Core.Model.Order> GetOrderDetails(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException("order id can not be null");
            }

            return this._OrderContext.Orders.Where(x => x.Id == id).Include(x => x.OrderDetails);
        }

    }
}
