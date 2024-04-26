using SportsPro.Models.DomainModels;

namespace SportsPro.Models.DomainModels
{
    public class IncidentManagerViewModel
    {
        public List<Incidents> incidents { get; set; }
        public string DisplayFilter { get; set; }

        public List<string> AvailableFilters { get; } = new List<string> { "All", "Unassigned", "Open" };
    }
}
