using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using System.Diagnostics;

namespace SportsPro.Controllers
{
    public class CustomersController : Controller
    {
        private SportsContext Context { get; set; }

        public CustomersController(SportsContext ctx)
        {
            Context = ctx;
        }

        public IActionResult CustomerList()
        {
            var customers = Context.Customers.Include(c => c.Country).OrderBy(c => c.FirstName).ToList();
            return View(customers);
        }

        public IActionResult AddCustomer()
        {
            ViewBag.Action = "Add Customer";
            ViewBag.Country = Context.Country.OrderBy(c => c.Name).ToList();

            var customer = new Customers();
            return View("EditCustomer", customer);
        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            ViewBag.Action = "Edit Customer";
            ViewBag.Country = Context.Country.OrderBy(c => c.Name).ToList();

            var customer = Context.Customers.Find(id);
            return View("EditCustomer", customer);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customers customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                {
                    Context.Customers.Add(customer);
                }
                else
                {
                    Context.Customers.Update(customer);
                }
                Context.SaveChanges();
                return RedirectToAction("CustomerList", "Customers");
            }
            else
            {
                ViewBag.Action = (customer.CustomerId == 0) ? "Add Customer" : "Edit Customer";
                ViewBag.Country = Context.Country.OrderBy(c => c.Name).ToList();
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = Context.Customers.Find(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult DeleteCustomer(Customers customer)
        {
            Context.Customers.Remove(customer);
            Context.SaveChanges();
            return RedirectToAction("CustomerList", "Customers");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
