using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomainDrivenDesign.Core.Model;
using DomainDrivenDesign.Infrastructure.CustomerInformation;
using DomainDrivenDesign.Core.Interfaces;
using DomainDrivenDesign.Infrastructure.CustomerInformation.Infrastructure.Data.Repositories;
using Microsoft.Practices.Unity;
using DomainDrivenDesign.Web.Models;

namespace DomainDrivenDesign.Web.Controllers
{
    public class CustomersController : Controller
    {
        private CustomerContext db = new CustomerContext(); // cutomer context will get deleted once the cusomter repository in full flash.
        private ICustomerRepository customerReposity;
        IUnityContainer container;
        public CustomersController(IUnityContainer contianer)
        {
            this.container = contianer;
            customerReposity = container.Resolve<ICustomerRepository>();
        }
        //GET: Customers
        public async Task<ActionResult> Index()
        {
            return View(await  customerReposity.Get());
        }
        //public ActionResult Index()
        //{
        //    return View(db.Customers.ToList());
        //}

        // GET: Customers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            CreateAddressViewModel customer = new CreateAddressViewModel();
           
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FirstName,Address1")] CreateAddressViewModel customer)
        {
            if (ModelState.IsValid)
            {
                // db.Customers.Add(customer);
                customerReposity.Add(new Customer() { FirstName = customer.FirstName, Addresses = new Address() { Address1 = customer.Address1 } });
                await customerReposity.CusotmerSaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FirstName")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Customer customer = await db.Customers.FindAsync(id);
            db.Customers.Remove(customer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
