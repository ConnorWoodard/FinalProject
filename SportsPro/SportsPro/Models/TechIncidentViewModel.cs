namespace SportsPro.Models
{
    public class TechIncidentViewModel
    {
        public Technicians Technician { get; set; } = null!;
        public Incidents Incident { get; set; } = null!;
        public IEnumerable<Incidents> Incidents { get; set; } = null!;
    }
}
