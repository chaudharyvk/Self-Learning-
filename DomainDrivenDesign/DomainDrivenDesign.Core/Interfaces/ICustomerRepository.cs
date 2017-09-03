using DomainDrivenDesign.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Core.Interfaces
{
   public interface ICustomerRepository 
    {
        void Add(Customer customer);
        void Remove(Customer customer);
        Task<List<Customer>> Get();
        void Update(Customer customer);
        Task<int> CusotmerSaveChangesAsync();

    }
}
