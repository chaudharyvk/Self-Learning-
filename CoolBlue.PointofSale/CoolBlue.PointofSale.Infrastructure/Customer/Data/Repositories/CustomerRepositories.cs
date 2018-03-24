using CoolBlue.PointofSale.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolBlue.PointofSale.Core.Model;

namespace CoolBlue.PointofSale.Infrastructure.Customer.Data.Repositories
{
    //todo Idisposable implement
    public class CustomerRepositories : ICustomerRepository
    {
        PointofSaleContext _customerContext;
        public CustomerRepositories(PointofSaleContext context)
        {
            this._customerContext = context;
        }

        public int Add(Core.Model.Customer customer)
        {
            //todo throw custom exception if user already registerd

            //if( GetCustomerByUserID(customer.UserId)!=null)
            // {
            //     throw CustomException();
            // }

            var cust = Core.Model.Customer.CreateCustomer(customer.UserId, customer.Password, customer.Addresses);
            this._customerContext.Customers.Add(cust);
                
            _customerContext.Entry(cust).State = System.Data.Entity.EntityState.Added;
            return this._customerContext.SaveChanges();
        }

        public int Add(string Userid, string password, Address address)
        {
            var cust = Core.Model.Customer.CreateCustomer(Userid, password, address);
            this._customerContext.Customers.Add(cust);

            _customerContext.Entry(cust).State = System.Data.Entity.EntityState.Added;
            return this._customerContext.SaveChanges();
        }

        public Task<int> CusotmerSaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Core.Model.Customer>> Get()
        {
            throw new NotImplementedException();
        }

        public Core.Model.Customer GetCustomerByUserID(string userid)
        {
         if (userid== null)
            {
                new ArgumentNullException("user id is null");

            }

            return this._customerContext.Customers.FirstOrDefault(x => x.UserId == userid);
        }

        public void Remove(Core.Model.Customer customer)
        {
            throw new NotImplementedException();
        }

        public int Update(Core.Model.Customer customer)
        {
            this._customerContext.Customers.Attach(customer);
            _customerContext.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            return this._customerContext.SaveChanges();
        }
    }
}
