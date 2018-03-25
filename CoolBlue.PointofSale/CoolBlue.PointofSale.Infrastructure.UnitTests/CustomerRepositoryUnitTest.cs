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
    public class CustomerRepositoryUnitTest : BaseUnitTest
    {

        const string UserID = "Virender";
        
        [TestMethod]
        public void AddNewCustomer()
        {
           var id = CreateNewCustomer(UserID);
            Assert.IsTrue(id>0);
        }

        private  int CreateNewCustomer(string UserID)
        {
            var addresses = new List<Address>() {
               new Address() { FirstName = "RenameBob1", LastName = "Martin", City = "Rotterdon", Country = "Netherland", PostalCode = 232 },
               new Address() { FirstName = "RenameBob2", LastName = "Martin", City = "Rotterdon", Country = "Netherland", PostalCode = 232 }
           };


            var custmer = new CoolBlue.PointofSale.Core.Model.Customer() { UserId = UserID, Password = "IAEA123" };

            return _CustomerRepository.Add(custmer,addresses);
        }

        [TestMethod]
        public void SearchCustomerByUserID()
        {
            string userid = UserID + new Random().Next();
            CreateNewCustomer(userid);
            Assert.IsNotNull(_CustomerRepository.GetCustomerByUserID(userid));
        }

        [TestMethod]
        public void UpdateCustomer()
        {

            string userid = UserID+ new Random().Next();
            CreateNewCustomer(userid);

            var customerdto = _CustomerRepository.GetCustomerByUserID(userid);
           
            customerdto.UserId = "Martin";
            customerdto.Password = "Luther1224!!!@";

            Assert.IsNotNull(_CustomerRepository.Update(customerdto,customerdto.Addresses.FirstOrDefault()));
        }

        [TestMethod]
        public void RemoveCustomer()
        {
            string userid = UserID + new Random().Next();
            CreateNewCustomer(userid);
         
            var customerdto = _CustomerRepository.GetCustomerByUserID(userid);
            var id = _CustomerRepository.Remove(customerdto);
            Assert.IsTrue(id > 0);

        }

        [TestMethod]
        public void CreateMultipleAddressOfSingleCustomer()
        {

            string userid = UserID + new Random().Next();


            var addresses = new List<Address>() {
               new Address() { FirstName = "RenameBob1", LastName = "Martin", City = "Rotterdon", Country = "Netherland", PostalCode = 232 },
               new Address() { FirstName = "RenameBob2", LastName = "Martin", City = "Rotterdon", Country = "Netherland", PostalCode = 232 }
           };

            var custmer = new CoolBlue.PointofSale.Core.Model.Customer() { UserId = userid, Password = "IAEA123" };


            _CustomerRepository.Add(custmer,addresses);
        }
    

    }
}
