using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models.DataLayer;
using SportsPro.Models.DomainModels;

namespace SportsPro.Controllers
{
    public class ValidationController : Controller
    {
        private Repository<Customers> Customerss { get; set; }

        public ValidationController(SportsContext context)
        {
            Customerss = new Repository<Customers>(context);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerifyEmail(string? email, int customerId)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {
                var existingCustomer = Customerss.Get(new QueryOptions<Customers>
                {
                    Where = c => c.Email == email
                });

                if (existingCustomer != null && existingCustomer.CustomerId != customerId)
                {
                    return Json($"Email '{email}' is already in use.");
                }
            }

            return Json(true);
        }

        //validate country method
        public IActionResult ValidateCountry(int? countryId)
        {
            if (countryId.HasValue && countryId > 0)
            {
                return Json(true); // Country is selected
            }
            return Json("Please select a country.");
        }


        public IActionResult ValidateFirstName(string firstName)
        {
            // Implement logic to check if the field has a value
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return Json($"Please enter a First Name");
            }

            return Json(true);
        }
    }
}
