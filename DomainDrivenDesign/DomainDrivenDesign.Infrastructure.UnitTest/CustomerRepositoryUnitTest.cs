using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainDrivenDesign.Core.Interfaces;
using DomainDrivenDesign.Infrastructure.CustomerInformation.Infrastructure.Data.Repositories;
using Moq;
using DomainDrivenDesign.ShareKernal;
using System.Threading;

namespace DomainDrivenDesign.Infrastructure.UnitTests
{
    [TestClass]
    public class CustomerRepositoryUnitTest
    {
        Mock<ICustomerRepository> mock;

        [TestInitialize]
        public void Setup()
        {
            mock = new Mock<ICustomerRepository>();
            mock.Setup(x => x.Add(new Core.Model.Customer() { FirstName = "Virendr", Addresses = new Core.Model.Address() { Address1 = "LeonardBernstiedStrasse" } })).Returns(1);
        }
        [TestMethod]
        public void Insert()
        {
            ICustomerRepository customer = new CustomerRepositories(new CustomerInformation.CustomerContext());
            var result = customer.Add(new Core.Model.Customer() { FirstName = "Virendr", Addresses = new Core.Model.Address() { Address1 = "LeonardBernstiedStrasse", PIN = 10 } });
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void InsertUsingTrakingEnum()
        {
            ICustomerRepository customer = new CustomerRepositories(new CustomerInformation.CustomerContext());
            customer.Update(new Core.Model.Customer() { FirstName = "Test Enum", TrackingState=TrackingState.Added, Addresses = new Core.Model.Address() { Address1 = "LeonardBernstiedStrasse", PIN = 10 } });
           // Thread.Sleep(200);
            //Assert.IsNotNull(result);

        }

        [TestMethod]
        public void TestMockInsertCustomerInformation()
        {
            //mock.();

        }
    }
}
