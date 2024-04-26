using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models.DataLayer;
using SportsPro.Models.DomainModels;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomersController : Controller
    {
        private Repository<Customers> customerss { get; set; }
        private Repository<Country> countrys { get; set; }
        public CustomersController(SportsContext ctx)
        {
            customerss = new Repository<Customers>(ctx);
            countrys = new Repository<Country>(ctx);
        }

        [Route("Customers")]
        public IActionResult CustomerList()
        {
            var customers = customerss.List(new QueryOptions<Customers>
            {
                OrderBy = c => c.FirstName
            });
            return View(customers);
        }

        public IActionResult AddCustomer()
        {
            ViewBag.Action = "Add Customer";
            ViewBag.CountrySelectList = new SelectList(countrys.List(new QueryOptions<Country> { OrderBy = c => c.Name }), "CountryId", "Name");

            var customer = new Customers();
            return View("EditCustomer", customer);
        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            ViewBag.Action = "Edit Customer";
            ViewBag.CountrySelectList = new SelectList(countrys.List(new QueryOptions<Country> { OrderBy = c => c.Name }), "CountryId", "Name");

            var customer = customerss.Get(id);
            return View("EditCustomer", customer);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customers customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.CustomerId == 0)
                {
                    customerss.Insert(customer);
                }
                else
                {
                    customerss.Update(customer);
                }
                customerss.Save();
                return RedirectToAction("CustomerList", "Customers");
            }
            else
            {
                ViewBag.Action = (customer.CustomerId == 0) ? "Add Customer" : "Edit Customer";
                ViewBag.CountrySelectList = new SelectList(countrys.List(new QueryOptions<Country> { OrderBy = c => c.Name }), "CountryId", "Name");
                return View(customer);
            }
        }

        [HttpGet]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = customerss.Get(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult DeleteCustomer(Customers customer)
        {
            customerss.Delete(customer);
            customerss.Save();
            return RedirectToAction("CustomerList", "Customers");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
