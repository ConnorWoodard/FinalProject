using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsPro.Models.DomainModels;
namespace SportsPro.Models.Configuration
{
    public class CustomersConfig : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> entity)
        {
            //fluent api to change the delete behavior to restrict


            entity.HasData(
                new Customers { CustomerId = 1, FirstName = "John", LastName = "Doe", Address = "123 Elm St", City = "Toronto", State = "ON", CountryId = 2, PostalCode = "M1M1M1", Email = "johndoe@sportsprosoftware.com", Phone = "800-565-0443" },
                new Customers { CustomerId = 2, FirstName = "Jane", LastName = "Smith", Address = "456 Oak St", City = "Vancouver", State = "BC", CountryId = 2, PostalCode = "V5V 5V5", Email = "smith523@sportsprosoftware.com", Phone = "810-565-0443" },
                new Customers { CustomerId = 3, FirstName = "Mike", LastName = "Jones", Address = "789 Pine St", City = "Montreal", State = "QC", CountryId = 2, PostalCode = "H3H 3H3", Email = "quebeclover12@sportsprosoftware.com", Phone = "820-565-0443" },
                new Customers { CustomerId = 4, FirstName = "Kaitlyn", LastName = "Anthoni", Address = "1010 Birch St", City = "San Francisco", State = "CA", CountryId = 1, PostalCode = "94101", Email = "kanthoni@gmail.com", Phone = "830-565-0578" },
                new Customers { CustomerId = 5, FirstName = "Karl", LastName = "Bronsom", Address = "1111 Cedar St", City = "Los Angeles", State = "CA", CountryId = 1, PostalCode = "90001", Email = "", Phone = "" }
            );
        }
    }
}
