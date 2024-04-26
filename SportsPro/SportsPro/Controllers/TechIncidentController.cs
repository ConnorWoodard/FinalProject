using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models.DataLayer;
using SportsPro.Models.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using SportsPro.Models;

namespace SportsPro.Controllers
{
    [Authorize]
    public class TechIncidentController : Controller
    {
        private const string TECH_KEY = "techId";

        private Repository<Technicians> Technicianss { get; set; }
        private Repository<Incidents> Incidentss { get; set; }

        public TechIncidentController(SportsContext ctx)
        {
            Technicianss = new Repository<Technicians>(ctx);
            Incidentss = new Repository<Incidents>(ctx);
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Get all technicians except the default technician
            ViewBag.Technicians = Technicianss.List(new QueryOptions<Technicians>
            {
                Where = t => t.TechnicianId != -1,
                OrderBy = t => t.Name
            });

            var technician = new Technicians();

            int? techId = HttpContext.Session.GetInt32(TECH_KEY);
            if (techId.HasValue)
            {
                technician = Technicianss.Get(techId.Value);
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
            var technician = Technicianss.Get(id);
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
                    Incidents = Incidentss.List(new QueryOptions<Incidents>
                    {
                        Where = i => i.TechnicianId == id && i.DateClosed == null,
                        OrderBy = i => i.DateOpened,
                        Includes = "Customer, Product"
                    })
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

            var technician = Technicianss.Get(techId.Value);
            if (technician == null)
            {
                TempData["message"] = "Technician not found. Please select a technician";
                return RedirectToAction("Index");
            }
            var incident = Incidentss.Get(new QueryOptions<Incidents>
            {
                Includes = "Customer,Product",
                Where = i => i.IncidentId == id
            });
            if(incident == null)
            {
                TempData["message"] = "Incident not found";
                return RedirectToAction("Index");
            }
            var model = new TechIncidentViewModel
            {
                Technician = technician,
                Incident = incident
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TechIncidentViewModel model)
        {
            Incidents i = Incidentss.Get(model.Incident.IncidentId);
            i.Description = model.Incident.Description;
            i.DateClosed = model.Incident.DateClosed;

            Incidentss.Update(i);
            Incidentss.Save();

            int? techId = HttpContext.Session.GetInt32(TECH_KEY);
            return RedirectToAction("List", new { id = techId });
        }
    }
}
