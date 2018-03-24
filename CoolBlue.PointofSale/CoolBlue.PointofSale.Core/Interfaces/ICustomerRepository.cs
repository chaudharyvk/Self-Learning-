using CoolBlue.PointofSale.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Core.Interfaces
{

    public interface ICustomerRepository
    {
        int Add(Customer customer);

        int Add(string Userid, string password, Address address);

        void Remove(Customer customer);
        Task<List<Customer>> Get();
        Customer GetCustomerByUserID(string userid);
        int Update(Customer customer);
        Task<int> CusotmerSaveChangesAsync();

    }
}
