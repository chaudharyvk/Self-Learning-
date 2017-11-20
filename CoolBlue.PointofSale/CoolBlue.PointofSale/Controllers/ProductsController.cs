using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CoolBlue.PointofSale.Core.Model;
using CoolBlue.PointofSale.Infrastructure;
using CoolBlue.PointofSale.Core.Interfaces;

namespace CoolBlue.PointofSale.Controllers
{
    public class ProductsController : ApiController
    {
        private PointofSaleContext db = new PointofSaleContext();
        private IProductRepository ProductRespostory;

        public ProductsController(IProductRepository productrepository)
        {

            ProductRespostory = productrepository;
           
        }

        // GET: api/Products
        // PBI 1                   
        public IQueryable<Product> GetProducts()
        {            
            return ProductRespostory.GetAllProduct();
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = this.ProductRespostory.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(string name)
        {
            var product = this.ProductRespostory.GetProductByName(name);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }



       

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prod = db.Products.FirstOrDefault(x=>x.Id==product.Id);

            if (product.Id != prod.Id)
            {
                return BadRequest();
            }
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;

            db.Entry(prod).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // db.Products.Add(product);
            // db.SaveChanges();

            var id = this.ProductRespostory.AddProduct(product);
            product = this.ProductRespostory.GetProductById(id);           
            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}