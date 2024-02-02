using Microsoft.EntityFrameworkCore;
namespace SportsPro.Models
{
    public class SportsContext : DbContext
    {
        public SportsContext(DbContextOptions<SportsContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; } = null!;

        public DbSet<Technicians> Technicians { get; set; } = null!;

        public DbSet<Customers> Customers { get; set; } = null!;

        public DbSet<Country> Country { get; set; } = null!;

        public DbSet<Incidents> Incidents { get; set; } = null!;

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

            modelBuilder.Entity<Country>().HasData(
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

            modelBuilder.Entity<Customers>().HasData(
                new Customers { CustomerId = 1, FirstName = "John", LastName = "Doe", Address = "123 Elm St", City = "Toronto", State = "ON", CountryId = 2, PostalCode = "M1M1M1", Email = "johndoe@sportsprosoftware.com", Phone = "800-565-0443" },
                new Customers { CustomerId = 2, FirstName = "Jane", LastName = "Smith", Address = "456 Oak St", City = "Vancouver", State = "BC", CountryId = 2, PostalCode = "V5V 5V5", Email = "smith523@sportsprosoftware.com", Phone = "810-565-0443" },
                new Customers { CustomerId = 3, FirstName = "Mike", LastName = "Jones", Address = "789 Pine St", City = "Montreal", State = "QC", CountryId = 2, PostalCode = "H3H 3H3", Email = "quebeclover12@sportsprosoftware.com", Phone = "820-565-0443" },
                new Customers { CustomerId = 4, FirstName = "Kaitlyn", LastName = "Anthoni", Address = "1010 Birch St", City = "San Francisco", State = "CA", CountryId = 1, PostalCode = "94101", Email = "kanthoni@gmail.com", Phone = "830-565-0578" },
                new Customers { CustomerId = 5, FirstName = "Karl", LastName = "Bronsom", Address = "1111 Cedar St", City = "Los Angeles", State = "CA", CountryId = 1, PostalCode = "90001", Email = "", Phone = "" }
                );

            modelBuilder.Entity<Incidents>().HasData(
                new Incidents { IncidentId = 1, CustomerId = 1, ProductId = 1, Title = "Could not install", Description = "Received error code 123 when trying to install", TechnicianId = 1, DateOpened = DateTime.Parse("2021-01-01"), DateClosed = null },
                new Incidents { IncidentId = 2, CustomerId = 2, ProductId = 2, Title = "Could not install", Description = "Received error code 123 when trying to install", TechnicianId = 2, DateOpened = DateTime.Parse("2021-01-01"), DateClosed = DateTime.Now },
                new Incidents { IncidentId = 3, CustomerId = 5, ProductId = 8, Title = "Error launching program", Description = "Program fails with error code 510, unable to open database.", TechnicianId = 3, DateOpened = DateTime.Parse("2022-09-10"), DateClosed = DateTime.Now },
                new Incidents { IncidentId = 4, CustomerId = 4, ProductId = 7, Title = "Error launching program", Description = "Program fails with error code 510, unable to open database.", TechnicianId = 4, DateOpened = DateTime.Parse("2022-09-10"), DateClosed = null }
                );
        }
    }
}
