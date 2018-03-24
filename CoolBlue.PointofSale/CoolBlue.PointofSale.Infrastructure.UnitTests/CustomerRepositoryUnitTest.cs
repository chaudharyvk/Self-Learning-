using CoolBlue.PointofSale.Core.Interfaces;
using CoolBlue.PointofSale.Core.Model;
using CoolBlue.PointofSale.Infrastructure.Customer.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Infrastructure.UnitTests
{
    [TestClass]
    public class CustomerRepositoryUnitTest
    {
        
        [TestMethod]
        public void AddNewCustomer()
        {

            ICustomerRepository product = new CustomerRepositories(new PointofSaleContext());

            Address address1 = new Address() { FirstName = "Virendra", LastName = "Martin",  City = "Rotterdon", Country = "Netherland", PostalCode = "1232" };

            var custmer = new CoolBlue.PointofSale.Core.Model.Customer() { UserId="Virender",Password="IAEA123", Addresses = address1};

            Assert.IsNotNull(product.Add(custmer));
        }

        [TestMethod]
        public void SearchCustomerByUserID()
        {
            ICustomerRepository customer = new CustomerRepositories(new PointofSaleContext());

            Assert.IsNotNull(customer.GetCustomerByUserID("RenameBob"));
        }

        [TestMethod]
        public void UpdateCustomer()
        {

            ICustomerRepository customer = new CustomerRepositories(new PointofSaleContext());

            var customerDetails = customer.GetCustomerByUserID("RenameBob");
            customerDetails.UserId = "RenameBob";

            Assert.IsNotNull(customer.Update(customerDetails));
        }

    }
}
