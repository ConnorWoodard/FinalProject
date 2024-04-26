using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using SportsPro.Models;
using SportsPro.Models.DataLayer;
using SportsPro.Models.DomainModels;
using System.Diagnostics;
using System.Globalization;

namespace SportsPro.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IncidentsController : Controller
    {
        private Repository<Incidents> incidentss { get; set; }
        private Repository<Customers> customerss { get; set; }
        private Repository<Products> productss { get; set; }
        private Repository<Technicians> technicianss { get; set; }

        public IncidentsController(SportsContext ctx)
        {
            incidentss = new Repository<Incidents>(ctx);
            customerss = new Repository<Customers>(ctx);
            productss = new Repository<Products>(ctx);
            technicianss = new Repository<Technicians>(ctx);
        }

        [Route("Incidents/{filter?}")]
        public IActionResult IncidentList(string filter)
        {
            var incidents = incidentss.List(new QueryOptions<Incidents>
            {
                Includes = "Customer,Product,Technician",
                OrderBy = i => i.DateOpened
            });

            switch (filter?.ToLower())
            {
                case "unassigned":
                    incidents = incidents.Where(i => i.TechnicianId == -1).ToList();
                    break;
                case "open":
                    incidents = incidents.Where(i => i.DateClosed == null).ToList();
                    break;
            }

            //use the incident manager view model
            var incidentsViewModel = new IncidentManagerViewModel
            {
                incidents = (List<Incidents>)incidents,
                DisplayFilter = filter ?? "All"
            };

            return View(incidentsViewModel);
        }

        //addincident using the view model
        public IActionResult AddIncident()
        {
            var viewModel = new AddEditIncidentViewModel
            {
                Customers = (List<Customers>)customerss.List(new QueryOptions<Customers>
                {
                    OrderBy = c => c.FirstName
                }),
                Products = (List<Products>)productss.List(new QueryOptions<Products>
                {
                    OrderBy = p => p.Name
                }),
                Technicians = (List<Technicians>)technicianss.List(new QueryOptions<Technicians>
                {
                    Where = t => t.TechnicianId != -1,
                    OrderBy = t => t.Name
                }),
                CurrentIncident = new Incidents
                {
                    DateOpened = DateTime.Now
                },
                Operation = "Add"
            };

            ViewBag.Customers = viewModel.Customers;
            ViewBag.Products = viewModel.Products;
            ViewBag.Technicians = viewModel.Technicians;

            return View("EditIncident", viewModel);
        }

        [HttpGet]
        public IActionResult EditIncident(int id)
        {
            var viewModel = new AddEditIncidentViewModel
            {
                Customers = (List<Customers>)customerss.List(new QueryOptions<Customers>
                {
                    OrderBy = c => c.FirstName
                }),
                Products = (List<Products>)productss.List(new QueryOptions<Products>
                {
                    OrderBy = p => p.Name
                }),
                Technicians = (List<Technicians>)technicianss.List(new QueryOptions<Technicians>
                {
                    Where = t => t.TechnicianId != -1,
                    OrderBy = t => t.Name
                }),
                CurrentIncident = incidentss.Get(id),
                Operation = "Edit",
                DisplayFilter = "All"
            };

            ViewBag.Customers = viewModel.Customers;
            ViewBag.Products = viewModel.Products;
            ViewBag.Technicians = viewModel.Technicians;

            return View("EditIncident", viewModel);
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
                    incidentss.Insert(viewModel.CurrentIncident);
                }
                else
                {
                    incidentss.Update(viewModel.CurrentIncident);
                }
                incidentss.Save();
                return RedirectToAction("IncidentList", "Incidents", new { filter = viewModel.DisplayFilter });
            }
            else
            {
                //Handle validation errors
                //Repopulate dropdown lists and return the view with the view model
                viewModel.Customers = (List<Customers>)customerss.List(new QueryOptions<Customers>
                {
                    OrderBy = c => c.FirstName
                });
                viewModel.Products = (List<Products>)productss.List(new QueryOptions<Products>
                {
                    OrderBy = p => p.Name
                });
                viewModel.Technicians = (List<Technicians>)technicianss.List(new QueryOptions<Technicians>
                {
                    Where = t => t.TechnicianId != -1,
                    OrderBy = t => t.Name
                });
                return View(viewModel);
            }
        }

        [HttpGet]
        public IActionResult DeleteIncident(int id)
        {
            var incident = incidentss.Get(id);
            ViewBag.Customers = customerss.List(new QueryOptions<Customers>
            {
                OrderBy = c => c.FirstName
            });
            return View(incident);
        }

        [HttpPost]
        public IActionResult DeleteIncident(Incidents incident)
        {
            incidentss.Delete(incident);
            incidentss.Save();
            return RedirectToAction("IncidentList", "Incidents", new { filter = "All" });
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
