using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoolBlue.PointofSale.Core.Interfaces;
using CoolBlue.PointofSale.Infrastructure;
using CoolBlue.PointofSale.Infrastructure.Product.Data;
using System.Linq;
namespace CoolBlue.PointofSale.Infrastructure.UnitTests
{
    [TestClass]
    public class ProductRepositoryUnitTest
    {
        [TestMethod]
        public void GetAllProduct()
        {
            IProductRepository product = new ProductRepositories(new PointofSaleContext() );
            
            Assert.IsTrue(product.GetAllProduct().ToList().Count>1);
        }

        [TestMethod]
        public void AddProuduct()
        {
            IProductRepository product = new ProductRepositories(new PointofSaleContext());

            Assert.IsNotNull(product.AddProduct(new Core.Model.Product() { Name = "Phone 7", Quantity = 20, Price = 444.44M }));
        }

        [TestMethod]
        public void SearchProduct()
        {
            IProductRepository product = new ProductRepositories(new PointofSaleContext());

            Assert.IsNotNull(product.GetProductById(1));
        }
    }
}
