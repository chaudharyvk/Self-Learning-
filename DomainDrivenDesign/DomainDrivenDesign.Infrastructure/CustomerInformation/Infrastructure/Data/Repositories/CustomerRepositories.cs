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
        public CustomerContext context;

        public CustomerRepositories(CustomerContext context)
        {
            this.context = context;
        }
        public void Add(Customer customer)
        {
            this.context.Customers.Add(customer);
            this.context.Entry(customer).State = System.Data.Entity.EntityState.Added;
            //this.context.SaveChangesAsync();

        }

        public Task<int> CusotmerSaveChangesAsync()
        {
           return this.context.SaveChangesAsync();
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
                    context.Dispose();
                }
            }
            this.disposed = true;
            //throw new NotImplementedException();

        }

        public void Remove(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> Get()
        {
            return context.Customers.ToListAsync();
        }
    }
}
