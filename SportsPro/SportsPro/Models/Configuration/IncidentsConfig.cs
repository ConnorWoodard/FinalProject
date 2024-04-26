using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsPro.Models.DomainModels;
namespace SportsPro.Models.Configuration
{
    public class IncidentsConfig : IEntityTypeConfiguration<Incidents>
    {
        public void Configure(EntityTypeBuilder<Incidents> entity)
        {
            entity.HasData(
                new Incidents { IncidentId = 1, CustomerId = 1, ProductId = 1, Title = "Could not install", Description = "Received error code 123 when trying to install", TechnicianId = 1, DateOpened = DateTime.Parse("2021-01-01"), DateClosed = null },
                new Incidents { IncidentId = 2, CustomerId = 2, ProductId = 2, Title = "Could not install", Description = "Received error code 123 when trying to install", TechnicianId = 2, DateOpened = DateTime.Parse("2021-01-01"), DateClosed = DateTime.Now },
                new Incidents { IncidentId = 3, CustomerId = 5, ProductId = 8, Title = "Error launching program", Description = "Program fails with error code 510, unable to open database.", TechnicianId = 3, DateOpened = DateTime.Parse("2022-09-10"), DateClosed = DateTime.Now },
                new Incidents { IncidentId = 4, CustomerId = 4, ProductId = 7, Title = "Error launching program", Description = "Program fails with error code 510, unable to open database.", TechnicianId = 4, DateOpened = DateTime.Parse("2022-09-10"), DateClosed = null }
            );
        }
    }
}
