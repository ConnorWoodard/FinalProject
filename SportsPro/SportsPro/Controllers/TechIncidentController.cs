using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    public class TechIncidentController : Controller
    {
        private const string TECH_KEY = "techId";

        private SportsContext Context { get; set; }
        public TechIncidentController(SportsContext ctx)
        {
            Context = ctx;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Technicians = Context.Technicians
                .Where(t => t.TechnicianId != -1)
                .OrderBy(c => c.Name)
                .ToList();

            var technician = new Technicians();

            int? techId = HttpContext.Session.GetInt32(TECH_KEY);
            if (techId.HasValue)
            {
                technician = Context.Technicians.Find(techId);
            }

            return View(technician);
        }

        [HttpPost]
        public IActionResult List(Technicians technician)
        {
            int? techId = HttpContext.Session.GetInt32(TECH_KEY);
            if (technician.TechnicianId == 0)
            {
                TempData["message"] = "You must select a technician.";
                return RedirectToAction("Index");
            }
            else
            {
                HttpContext.Session.SetInt32(TECH_KEY, technician.TechnicianId);
                return RedirectToAction("List", new { id = technician.TechnicianId });
            }
        }

        [HttpGet]
        public IActionResult List(int id)
        {
            var technician = Context.Technicians.Find(id);
            if (technician == null)
            {
                TempData["message"] = "Technician not found. Please select a technician";
                return RedirectToAction("Index");
            }
            else
            {
                var model = new TechIncidentViewModel
                {
                    Technician = technician,
                    Incidents = Context.Incidents
                        .Include(i => i.Customer)
                        .Include(i => i.Product)
                        .Where(i => i.TechnicianId == id && i.DateClosed == null)
                        .OrderBy(i => i.DateOpened)
                        .ToList()
                };
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            int? techId = HttpContext.Session.GetInt32(TECH_KEY);
            if (!techId.HasValue)
            {
                TempData["message"] = "Technician not found. Please select a technician";
                return RedirectToAction("Index");
            }

            var technician = Context.Technicians.Find(techId);
            if (technician == null)
            {
                TempData["message"] = "Technician not found. Please select a technician";
                return RedirectToAction("Index");
            }
            else
            {
                var model = new TechIncidentViewModel
                {
                    Technician = technician,
                    Incident = Context.Incidents
                        .Include(i => i.Customer)
                        .Include(i => i.Product)
                        .FirstOrDefault(i => i.IncidentId == id)
                };
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Edit(TechIncidentViewModel model)
        {
            Incidents i = Context.Incidents.Find(model.Incident.IncidentId);
            i.Description = model.Incident.Description;
            i.DateClosed = model.Incident.DateClosed;

            Context.Incidents.Update(i);
            Context.SaveChanges();

            int? techId = HttpContext.Session.GetInt32(TECH_KEY);
            return RedirectToAction("List", new { id = techId });
        }
    }
}
