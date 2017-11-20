using CoolBlue.PointofSale.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolBlue.PointofSale.Core.Model;
using System.Data.Entity;

namespace CoolBlue.PointofSale.Infrastructure.Product.Data
{
    public class ProductRepositories : IProductRepository, IDisposable
    {
        public PointofSaleContext _produtContext;

        public ProductRepositories(PointofSaleContext context)
        {
            this._produtContext = context;
        }
        public int AddProduct(Core.Model.Product product)
        {
            this._produtContext.Products.Add(product);

            _produtContext.Entry(product).State = System.Data.Entity.EntityState.Added;
           return this._produtContext.SaveChanges();
          
        }

      
        public IQueryable<Core.Model.Product> GetAllProduct()
        {
            return _produtContext.Products.OrderByDescending(x=>x.Id);
        }

        public Core.Model.Product GetProductById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException("Product Not Found");
            }
           return  _produtContext.Products.FirstOrDefault(x =>x.Id == id);
          
        }

        public  IQueryable<Core.Model.Product> GetProductByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Product Not Found");
            }
            return _produtContext.Products.Where(x => x.Name.Contains(name));

        }



        public Task<int> ProductSaveChangesAsync()
        {

           return this._produtContext.SaveChangesAsync();
      
        }

        public void Remove(Core.Model.Product customer)
        {
            throw new NotImplementedException();
        }

        public void Update(Core.Model.Product customer)
        {
            throw new NotImplementedException();
        }

#region Dispose

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
                    _produtContext.Dispose();
                }
            }
            this.disposed = true;
            //throw new NotImplementedException();

        }

       
        #endregion
    }
}
