using Microsoft.AspNetCore.Mvc;
using CH2Labs.Models;
namespace CH2Labs.Controllers
{
    public class PriceQuotation : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Message = "Price Quotation";
            return View();
        }

        [HttpPost]
        public IActionResult Index(PriceQuotationModel p1)
        {
            p1.CalculateTotal();
            return View(p1);
        }
    }
}
