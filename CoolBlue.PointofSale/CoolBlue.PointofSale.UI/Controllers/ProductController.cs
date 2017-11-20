using CoolBlue.PointofSale.Core.Model;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CoolBlue.PointofSale.UI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        string baseURL = "http://localhost/";
        public async System.Threading.Tasks.Task<ActionResult> Index(string sortOrder, string currentFilter,string searchString,int?page)
        {
            ViewBag.CurrentFilter = searchString;
            var product = new List<CoolBlue.PointofSale.UI.Models.ProductViewModel>();
            using (var client = new HttpClient())
            {
                HttpResponseMessage Res = null;
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(searchString))
                {
                     Res = await client.GetAsync(string.Format("CoolBlue.PointofSale/api/products/?name={0}", searchString));

                }
                else
                {
                    Res = await client.GetAsync("CoolBlue.PointofSale/api/products");

                }
                if (Res.IsSuccessStatusCode)
                {

                    var productResponse = Res.Content.ReadAsStringAsync().Result;
                   var product1 = JsonConvert.DeserializeObject<List<Product>>(productResponse);

                    foreach(var p in product1)
                    {
                        product.Add(new Models.ProductViewModel { Id = p.Id,Name=p.Name,Quantity=p.Quantity,Price=p.Price });
                    }

                    int pageSize = 25;
                    int pageNumber = (page ?? 1);
                    return View(product.ToPagedList(pageNumber, pageSize));
                }
            }
            return View();

        }

        // GET: Product/Details/5
        public async System.Threading.Tasks.Task<ActionResult> Details(int id)
        {
            var product = new Product();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync(string.Format("CoolBlue.PointofSale/api/products/{0}", id));
                if (Res.IsSuccessStatusCode)
                {

                    var productResponse = Res.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<Product>(productResponse);
                }
                return View(product);
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="Name,Price,Quantity")]Product product)
        {
            try
            {
                // TODO: Add insert logic here

                using (var client = new HttpClient())
                {
                    baseURL = "http://localhost/CoolBlue.PointofSale/api/products";
                    client.BaseAddress = new Uri(baseURL);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var puttask = client.PostAsJsonAsync<Product>("products", product);
                    puttask.Wait();
                    var result = puttask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public async System.Threading.Tasks.Task<ActionResult> Edit(int id)
        {
            Product product = new Product();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync(string.Format("CoolBlue.PointofSale/api/products/{0}", id));
                if (Res.IsSuccessStatusCode)
                {

                    var productResponse = Res.Content.ReadAsStringAsync().Result;
                    product = JsonConvert.DeserializeObject<Product>(productResponse);
                }
                return View(product);
            }
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Name,Price,Quantity")]Product product,int id)
        {
            try
            {
                try
                {
                    // TODO: Add insert logic here

                    using (var client = new HttpClient())
                    {
                        baseURL = "http://localhost/CoolBlue.PointofSale/api/products";
                        client.BaseAddress = new Uri(baseURL);
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        product.Id = id;
                        var puttask = client.PutAsJsonAsync<Product>("products", product);
                        puttask.Wait();
                        var result = puttask.Result;
                        if (result.IsSuccessStatusCode)
                        {

                            return RedirectToAction("Index");
                        }
                    }
                    return View();
                }
                catch
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
