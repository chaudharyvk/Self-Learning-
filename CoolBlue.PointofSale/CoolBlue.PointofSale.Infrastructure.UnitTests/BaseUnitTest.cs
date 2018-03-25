using CoolBlue.PointofSale.Core.Interfaces;
using CoolBlue.PointofSale.Infrastructure.Customer.Data.Repositories;

namespace CoolBlue.PointofSale.Infrastructure.UnitTests
{
    public class BaseUnitTest
    {
        protected ICustomerRepository _CustomerRepository {  get { return new CustomerRepositories(new PointofSaleContext()); } }
    }
}