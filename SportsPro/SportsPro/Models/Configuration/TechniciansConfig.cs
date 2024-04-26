using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsPro.Models.DomainModels;
namespace SportsPro.Models.Configuration
{
    public class TechniciansConfig : IEntityTypeConfiguration<Technicians>
    {
        public void Configure(EntityTypeBuilder<Technicians> entity)
        {
            entity.HasData(
                new Technicians { TechnicianId = -1, Name = "Not assigned", Email = "na@gmail.com", Phone = "111-111-1111" },
                new Technicians { TechnicianId = 1, Name = "Alison Diaz", Email = "alison@sportsprosoftware.com", Phone = "800-555-0443" },
                new Technicians { TechnicianId = 2, Name = "Allan Deyoung", Email = "adeyoung@sportsprosoftware.com", Phone = "800-555-5555" },
                new Technicians { TechnicianId = 3, Name = "Drew Douglas", Email = "ddouglas@gmai.com", Phone = "800-555-0423" },
                new Technicians { TechnicianId = 4, Name = "Gunter Wendt", Email = "gunter@sportsprosoftware.com", Phone = "800-555-0453" },
                new Technicians { TechnicianId = 5, Name = "Jim Wilson", Email = "jwilson23@sportsprosoftware.com", Phone = "800-555-0449" }
                );
        }
    }

}
