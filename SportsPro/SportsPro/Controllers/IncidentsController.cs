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

        [Route("Incidents")]
        public IActionResult IncidentList(string filter)
        {
            var incidents = Context.Incidents.Include(i => i.Customer).Include(i => i.Product).Include(i => i.Technician).OrderBy(i => i.DateOpened).ToList();

            //Apply filtering logic based on the filter parameter
            if (!string.IsNullOrEmpty(filter))
            {
                switch (filter.ToLower())
                {
                    case "unassigned":
                        incidents = incidents.Where(i => i.TechnicianId == 0).ToList();
                        break;
                    case "open":
                        incidents = incidents.Where(i => i.DateClosed == null).ToList();
                        break;
                        // Add more cases as needed
                }
            }

            //Order the incidents by date opened
            var filteredIncidents = incidents.OrderBy(i => i.DateOpened).ToList();

            var incidentsViewModel = new IncidentManagerViewModel
            {
                incidents = filteredIncidents,
                DisplayFilter = filter
            };

            return View(incidentsViewModel);
        }

        public IActionResult AddIncident()
        {
            /*            ViewBag.Action = "Add Incident";
                        ViewBag.Customers = Context.Customers.OrderBy(c => c.FirstName).ToList();
                        ViewBag.Products = Context.Products.OrderBy(p => p.Name).ToList();
                        ViewBag.Technicians = Context.Technicians.OrderBy(t => t.Name).ToList();

                        var incident = new Incidents()
                        {
                            DateOpened = DateTime.Now
                        };
            */
            var viewModel = new AddEditIncidentViewModel
            {
                Customers = Context.Customers.OrderBy(c => c.FirstName).ToList(),
                Products = Context.Products.OrderBy(p => p.Name).ToList(),
                Technicians = Context.Technicians.Where(t => t.TechnicianId != -1).OrderBy(t => t.Name).ToList(),
                CurrentIncident = new Incidents
                {
                    DateOpened = DateTime.Now
                },
                Operation = "Add"
            };
            return View("EditIncident", viewModel);
        }

        [HttpGet]
        public IActionResult EditIncident(int id)
        {
/*            ViewBag.Action = "Edit Incident";
            ViewBag.Customers = Context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Products = Context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = Context.Technicians.Where(t => t.TechnicianId != -1).OrderBy(t => t.Name).ToList();

            var incident = Context.Incidents.Find(id);*/
            var viewModel = new AddEditIncidentViewModel
            {
                Customers = Context.Customers.OrderBy(c => c.FirstName).ToList(),
                Products = Context.Products.OrderBy(p => p.Name).ToList(),
                Technicians = Context.Technicians.Where(t => t.TechnicianId != -1).OrderBy(t => t.Name).ToList(),
                CurrentIncident = Context.Incidents.Find(id),
                Operation = "Edit",
                DisplayFilter = "All"
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditIncident(AddEditIncidentViewModel viewModel)
        {
            ModelState.Remove("Customers");
            ModelState.Remove("Products");
            ModelState.Remove("Technicians");
            ModelState.Remove("DisplayFilter");
            if (ModelState.IsValid)
            {
                if (viewModel.CurrentIncident.IncidentId == 0)
                {
                    Context.Incidents.Add(viewModel.CurrentIncident);
                }
                else
                {
                    Context.Incidents.Update(viewModel.CurrentIncident);
                }
                Context.SaveChanges();
                return RedirectToAction("IncidentList", "Incidents", new { filter = viewModel.DisplayFilter });
            }
            else
            {
                //Handle validation errors
                //Repopulate dropdown lists and return the view with the view model
                viewModel.Customers = Context.Customers.OrderBy(c => c.FirstName).ToList();
                viewModel.Products = Context.Products.OrderBy(p => p.Name).ToList();
                viewModel.Technicians = Context.Technicians.Where(t => t.TechnicianId != -1).OrderBy(t => t.Name).ToList();
                return View(viewModel);
            }
        }
/*        {

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
        }*/

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
            return RedirectToAction("IncidentList", "Incidents", new { filter = "All"});
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
