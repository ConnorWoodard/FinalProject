using Microsoft.EntityFrameworkCore;
namespace SportsPro.Models
{
    public class SportsContext : DbContext
    {
        public SportsContext(DbContextOptions<SportsContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; } = null!;

        public DbSet<Technicians> Technicians { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
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

            modelBuilder.Entity<Technicians>().HasData(
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
