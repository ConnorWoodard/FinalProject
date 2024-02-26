namespace SportsPro.Models
{
    public class AddEditIncidentViewModel
    {
        public Incidents CurrentIncident { get; set; }
        public List<Customers> Customers { get; set; }
        public List<Products> Products { get; set; }
        public List<Technicians> Technicians { get; set; }

        public string Operation { get; set; }

        public string DisplayFilter { get; set; }
    }
}
