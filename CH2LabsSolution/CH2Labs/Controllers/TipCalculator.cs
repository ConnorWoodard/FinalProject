using Microsoft.AspNetCore.Mvc;
using CH2Labs.Models;
namespace CH2Labs.Controllers
{
    public class TipCalculator : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Message = "Tip Calculator";

            return View();
        }

        [HttpPost]
        public IActionResult Index(TipCalculationModel t1)
        {
            t1.CalculateTipAmount();
            return View(t1);
        }
    }
}
