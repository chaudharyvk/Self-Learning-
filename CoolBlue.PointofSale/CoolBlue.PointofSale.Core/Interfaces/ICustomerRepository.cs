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
        int Add(Customer customer,ICollection<Address> address);

        int Add(string Userid, string password,ICollection<Address> address);

        int Remove(Customer customer);
        Task<List<Customer>> Get();
        Customer GetCustomerByUserID(string userid);
        int Update(Customer customer, Address address);
        Task<int> CusotmerSaveChangesAsync();

    }
}
