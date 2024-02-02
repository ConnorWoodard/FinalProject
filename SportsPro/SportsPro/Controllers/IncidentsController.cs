using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using System.Diagnostics;
using System.Globalization;

namespace SportsPro.Controllers
{
    public class IncidentsController : Controller
    {
        private SportsContext Context { get; set; }

        public IncidentsController(SportsContext ctx)
        {
            Context = ctx;
        }

        public IActionResult IncidentList()
        {
            var incidents = Context.Incidents.Include(i => i.Customer).Include(i => i.Product).Include(i => i.Technician).OrderBy(i => i.DateOpened).ToList();
            return View(incidents);
        }

        public IActionResult AddIncident()
        {
            ViewBag.Action = "Add Incident";
            ViewBag.Customers = Context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Products = Context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = Context.Technicians.Where(t => t.TechnicianId != -1).OrderBy(t => t.Name).ToList();

            var incident = new Incidents()
            {
                DateOpened = DateTime.Now
            };

            return View("EditIncident", incident);
        }

        [HttpGet]
        public IActionResult EditIncident(int id)
        {
            ViewBag.Action = "Edit Incident";
            ViewBag.Customers = Context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Products = Context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = Context.Technicians.Where(t => t.TechnicianId != -1).OrderBy(t => t.Name).ToList();

            var incident = Context.Incidents.Find(id);
            return View(incident);
        }

        [HttpPost]
        public IActionResult EditIncident(Incidents incident)
        {

            if (ModelState.IsValid)
            {
                if (incident.IncidentId == 0)
                {
                    Context.Incidents.Add(incident);
                }
                else
                {
                    Context.Incidents.Update(incident);
                }
                Context.SaveChanges();
                return RedirectToAction("IncidentList", "Incidents");
            }
            else
            {
                ViewBag.Action = (incident.IncidentId == 0) ? "Add Incident" : "Edit Incident";
                ViewBag.Customers = Context.Customers.OrderBy(c => c.FirstName).ToList();
                ViewBag.Products = Context.Products.OrderBy(p => p.Name).ToList();
                ViewBag.Technicians = Context.Technicians.Where(t => t.TechnicianId != -1).OrderBy(t => t.Name).ToList();
                return View(incident);
            }
        }

        [HttpGet]
        public IActionResult DeleteIncident(int id)
        {
            var incident = Context.Incidents.Find(id);
            ViewBag.Customers = Context.Customers.OrderBy(c => c.FirstName).ToList();
            return View(incident);
        }

        [HttpPost]
        public IActionResult DeleteIncident(Incidents incident)
        {
            Context.Incidents.Remove(incident);
            ViewBag.Customers = Context.Customers.OrderBy(c => c.FirstName).ToList();
            Context.SaveChanges();
            return RedirectToAction("IncidentList", "Incidents");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
