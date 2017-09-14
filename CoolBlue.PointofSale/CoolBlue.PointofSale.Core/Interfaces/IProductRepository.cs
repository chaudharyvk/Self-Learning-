using CoolBlue.PointofSale.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolBlue.PointofSale.Core.Interfaces
{
   public interface IProductRepository
    {
        int AddProduct(Product product);
        void Remove(Product product);
        IQueryable<Product> GetAllProduct();
        Product GetProductById(int productid);
        void Update(Product product);
        Task<int> ProductSaveChangesAsync();
    }
}
