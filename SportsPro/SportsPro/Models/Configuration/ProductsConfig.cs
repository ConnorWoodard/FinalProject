using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsPro.Models.DomainModels;
namespace SportsPro.Models.Configuration
{
    public class ProductsConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> entity)
        {
            entity.HasData(
                new Products { ProductId = 1, ProductCode = "TRNY10", Name = "Tournament Master 1.0", YearlyPrice = 4.99M, ReleaseDate = DateTime.Parse("2015-01-01") },
                new Products { ProductId = 2, ProductCode = "LEAG10", Name = "League Scheduler 1.0", YearlyPrice = 4.99M, ReleaseDate = DateTime.Parse("2016-01-01") },
                new Products { ProductId = 3, ProductCode = "TEAM10", Name = "Team Manager 1.0", YearlyPrice = 4.99M, ReleaseDate = DateTime.Parse("2017-01-01") },
                new Products { ProductId = 4, ProductCode = "TRNY11", Name = "Tournament Master 1.1", YearlyPrice = 5.99M, ReleaseDate = DateTime.Parse("2018-01-01") },
                new Products { ProductId = 5, ProductCode = "LEAG11", Name = "League Scheduler 1.1", YearlyPrice = 5.99M, ReleaseDate = DateTime.Parse("2019-01-01") },
                new Products { ProductId = 6, ProductCode = "TEAM11", Name = "Team Manager 1.1", YearlyPrice = 5.99M, ReleaseDate = DateTime.Parse("2020-01-01") },
                new Products { ProductId = 7, ProductCode = "TRNY20", Name = "Tournament Master 2.0", YearlyPrice = 8.99M, ReleaseDate = DateTime.Parse("2021-01-01") },
                new Products { ProductId = 8, ProductCode = "LEAG20", Name = "League Scheduler 2.0", YearlyPrice = 8.99M, ReleaseDate = DateTime.Parse("2021-01-01") },
                new Products { ProductId = 9, ProductCode = "TEAM20", Name = "Team Manager 2.0", YearlyPrice = 8.99M, ReleaseDate = DateTime.Parse("2021-01-01") }
                );
        }
    }
}
