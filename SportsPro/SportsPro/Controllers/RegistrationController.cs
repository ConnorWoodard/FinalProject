using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models.DataLayer;
using SportsPro.Models.DomainModels;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RegistrationController : Controller
    {
        private readonly SportsContext _context;

        public RegistrationController(SportsContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Register()
        {
            ViewBag.Customers = await _context.Customers.ToListAsync();
            return View(await _context.Products.ToListAsync());
        }
        public async Task<IActionResult> ChangeCustomer(int customerId)
        {
            ViewBag.Customers = await _context.Customers.ToListAsync();
            ViewBag.SelectedCustomer = customerId;
            if (customerId != 0)
            {
                var productsRegistered = await _context.Products
                    .Where(p => p.Customer.Any(c => c.CustomerId == customerId))
                    .ToListAsync();

                var unregisteredProducts = await _context.Products
                    .Where(p => !p.Customer.Any(c => c.CustomerId == customerId))
                    .ToListAsync();

                ViewBag.ProductsRegistered = productsRegistered;
                ViewBag.UnregisteredProducts = unregisteredProducts;
            }
            else
            {
                ViewBag.ProductsRegistered = new List<Products>();
                ViewBag.UnregisteredProducts = await _context.Products.ToListAsync();
                ViewBag.SelectedCustomer = null;
            }

            return View("Register");
        }


        [HttpGet]
        public async Task<IActionResult> RegisterNewProduct(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            var unregisteredProducts = await _context.Products
                .Where(p => !p.Customer.Any(c => c.CustomerId == customerId))
                .ToListAsync();

            ViewBag.CustomerName = $"{customer.FullName}";
            ViewBag.CustomerId = customerId;
            ViewBag.Products = unregisteredProducts;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterNewProduct(int customerId, int productId)
        {
            if (customerId == 0 || productId == 0)
            {
                return RedirectToAction("Index");
            }
            var customer = await _context.Customers.Include(c => c.Product).FirstOrDefaultAsync(c => c.CustomerId == customerId);
            if (customer == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }
            if (!customer.Product.Any(p => p.ProductId == productId))
            {
                customer.Product.Add(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ChangeCustomer", new { customerId });
        }

        public async Task<IActionResult> RemoveRegistration(int customerId, int productId)
        {
            if (customerId == 0 || productId == 0)
            {
                return RedirectToAction("Index");
            }
            var customer = await _context.Customers.Include(c => c.Product).FirstOrDefaultAsync(c => c.CustomerId == customerId);
            if (customer == null)
            {
                return NotFound();
            }
            var productToRemove = customer.Product.FirstOrDefault(p => p.ProductId == productId);
            if (productToRemove != null)
            {
                customer.Product.Remove(productToRemove);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("ChangeCustomer", new { customerId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    return RedirectToAction("ChangeCustomer", new { customerId });
                }
            }
            else
            {
                return RedirectToAction("ChangeCustomer", new { customerId });
            }
        }
    }
}
