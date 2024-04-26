using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsPro.Models.DomainModels;
namespace SportsPro.Models.Configuration
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.HasData(
                new Country { CountryId = 1, Name = "USA" },
                new Country { CountryId = 2, Name = "Canada" },
                new Country { CountryId = 3, Name = "England" },
                new Country { CountryId = 4, Name = "France" },
                new Country { CountryId = 5, Name = "Germany" },
                new Country { CountryId = 6, Name = "Italy" },
                new Country { CountryId = 7, Name = "Spain" },
                new Country { CountryId = 8, Name = "Mexico" },
                new Country { CountryId = 9, Name = "Brazil" },
                new Country { CountryId = 10, Name = "Argentina" }
            );
        }
    }

}
