using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace SportsPro.Controllers
{
    public class TechniciansController : Controller
    {
        private SportsContext Context { get; set; }

        public TechniciansController(SportsContext ctx)
        {
            Context = ctx;
        }

        public IActionResult TechnicianList()
        {
            var technicians = Context.Technicians.Where(t => t.TechnicianId != -1).OrderBy(t => t.Name).ToList();
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

            var technician = Context.Technicians.Find(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult EditTechnician(Technicians technician)
        {
            if (ModelState.IsValid)
            {
                if (technician.TechnicianId == 0)
                {
                    Context.Technicians.Add(technician);
                }
                else
                {
                    Context.Technicians.Update(technician);
                }
                Context.SaveChanges();
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
            var technician = Context.Technicians.Find(id);
            return View(technician);
        }

        [HttpPost]
        public IActionResult DeleteTechnician(Technicians technician)
        {
            Context.Technicians.Remove(technician);
            Context.SaveChanges();
            return RedirectToAction("TechnicianList");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
