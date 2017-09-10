using DomainDrivenDesign.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDrivenDesign.Core.Model;
using System.Data.Entity;

namespace DomainDrivenDesign.Infrastructure.CustomerInformation.Infrastructure.Data.Repositories
{
    public class CustomerRepositories : ICustomerRepository,IDisposable
    {
        public CustomerContext _context;

        public CustomerRepositories(CustomerContext context)
        {
            this._context = context;
        }
        public int Add(Customer customer)
        {

            this._context.Customers.Add(customer);
                      
            this._context.Entry(customer).State = System.Data.Entity.EntityState.Added;
           var result= this.CusotmerSaveChangesAsync();
            return result.Result;

        }

        public void Update(Customer customer)
        {
            //  this._context.Entry(customer).State = EntityState.Modified;

            // add and delete appointments

        
            if (customer.TrackingState == ShareKernal.TrackingState.Added)
            {
                this._context.Customers.Add(customer);
                this._context.Entry(customer).State = EntityState.Added;
            }
            if (customer.TrackingState == ShareKernal.TrackingState.Modified)
            {
                this._context.Entry(customer).State = EntityState.Modified;
            }
            if (customer.TrackingState == ShareKernal.TrackingState.Deleted)
            {
                this._context.Entry(customer).State = EntityState.Deleted;
            }

            this._context.SaveChanges();
        }

        public Task<int> CusotmerSaveChangesAsync()
        {
           return this._context.SaveChangesAsync();
        }
        private bool disposed;

        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposing)
        {
            if (!disposed)
            {
                if (isdisposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
            //throw new NotImplementedException();

        }

        public void Remove(Customer customer)
        {
            throw new NotImplementedException();
        }

       

        public Task<List<Customer>> Get()
        {
            return _context.Customers.ToListAsync();
        }
    }
}
