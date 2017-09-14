using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoolBlue.PointofSale.Core.Interfaces;
using CoolBlue.PointofSale.Infrastructure.Order.Data.Repositories;
using CoolBlue.PointofSale.Infrastructure.Customer.Data.Repositories;
using CoolBlue.PointofSale.Infrastructure.Product.Data;
using System.Collections.Generic;
using System.Linq;

namespace CoolBlue.PointofSale.Infrastructure.UnitTests
{
    [TestClass]
    public class OrderRepositoryUnitTest
    {
        [TestMethod]
        public void PlaceOrder()

        { 
            ICustomerRepository customerRepository = new CustomerRepositories(new PointofSaleContext());

            var customerDetails = customerRepository.GetCustomerByUserID("Virender");
                
            IOrderRepository orderRepository = new OrderRepositories(new PointofSaleContext());

            IProductRepository productRepository = new ProductRepositories(new PointofSaleContext());

            var productDetail = new List<Core.Model.Product>();

            productDetail.Add(productRepository.GetProductById(1));

            Assert.IsTrue((orderRepository.PlaceOrder(customerDetails, productDetail)) >0 );
        }

        [TestMethod]
        public void GetAllOrderPlaced()
        {
            IOrderRepository orderRepository = new OrderRepositories(new PointofSaleContext());
            var orderdetails = orderRepository.GetOrderDetails(2).ToList();
            Assert.IsTrue(orderdetails.Any());

        }

    }
}
