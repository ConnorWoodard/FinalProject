using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using SportsPro.Models.DataLayer;
using SportsPro.Models.DomainModels;
using Microsoft.AspNetCore.Authorization;

namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TechniciansController : Controller
    {
        private Repository<Technicians> Technicianss { get; set; }

        public TechniciansController(SportsContext ctx)
        {
            Technicianss = new Repository<Technicians>(ctx);
        }

        [Route("Technicians")]
        public IActionResult TechnicianList()
        {
            var technicians = Technicianss.List(new QueryOptions<Technicians>
            {
                OrderBy = t => t.Name
            });
            return View(technicians);
        }

        public IActionResult AddTechnician()
        {
            ViewBag.Action = "Add Technician";
            var technician = new Technicians();
            return View("EditTechnician", technician);
        }

        [HttpGet]
        public IActionResult EditTechnician(int id)
        {
            ViewBag.Action = "Edit Technician";

            var technician = Technicianss.Get(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult EditTechnician(Technicians technician)
        {
            if (ModelState.IsValid)
            {
                if (technician.TechnicianId == 0)
                {
                    Technicianss.Insert(technician);
                }
                else
                {
                    Technicianss.Update(technician);
                }
                Technicianss.Save();
                return RedirectToAction("TechnicianList", "Technicians");
            }
            else
            {
                ViewBag.Action = (technician.TechnicianId == 0) ? "Add Technician" : "Edit Technician";
                return View(technician);
            }
        }

        [HttpGet]
        public IActionResult DeleteTechnician(int id)
        {
            var technician = Technicianss.Get(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult DeleteTechnician(Technicians technician)
        {
            Technicianss.Delete(technician);
            Technicianss.Save();
            return RedirectToAction("TechnicianList", "Technicians");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
