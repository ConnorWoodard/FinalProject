using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SportsPro.Models.DomainModels
{
    public class SportsContext : IdentityDbContext<User>
    {
        public SportsContext(DbContextOptions<SportsContext> options) : base(options) { }

        public DbSet<Products> Products { get; set; } = null!;

        public DbSet<Technicians> Technicians { get; set; } = null!;

        public DbSet<Customers> Customers { get; set; } = null!;

        public DbSet<Country> Country { get; set; } = null!;

        public DbSet<Incidents> Incidents { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new Configuration.ProductsConfig());


            modelBuilder.ApplyConfiguration(new Configuration.TechniciansConfig());


            modelBuilder.ApplyConfiguration(new Configuration.CountryConfig());

            modelBuilder.ApplyConfiguration(new Configuration.CustomersConfig());


            modelBuilder.ApplyConfiguration(new Configuration.IncidentsConfig());


            //modelBuilder.Entity<Products>().HasMany(p => p.Customer).WithMany(c => c.Product).UsingEntity(pc => pc.HasData(
            //    new { ProductsProductId = 1, CustomersCustomerId = 1 },
            //    new { ProductsProductId = 2, CustomersCustomerId = 1 },
            //    new { ProductsProductId = 2, CustomersCustomerId = 2 },
            //    new { ProductsProductId = 3, CustomersCustomerId = 3 },
            //    new { ProductsProductId = 3, CustomersCustomerId = 4 },
            //    new { ProductsProductId = 5, CustomersCustomerId = 4 },
            //    new { ProductsProductId = 8, CustomersCustomerId = 5 }
            //    ));

            modelBuilder.Entity<Products>()
            .HasMany(p => p.Customer)
            .WithMany(c => c.Product)
            .UsingEntity<Dictionary<string, object>>(
             "CustomerProducts",
             j => j.HasOne<Customers>().WithMany().HasForeignKey("CustomersId"),
             j => j.HasOne<Products>().WithMany().HasForeignKey("ProductsId"),
               j =>
               {
                   j.HasData(new { CustomersId = 1, ProductsId = 1 },


                             new { ProductsId = 2, CustomersId = 1 },
                             new { ProductsId = 2, CustomersId = 2 },
                             new { ProductsId = 3, CustomersId = 3 },
                             new { ProductsId = 3, CustomersId = 4 },
                             new { ProductsId = 5, CustomersId = 4 },
                             new { ProductsId = 8, CustomersId = 5 });
               });
        }
    }
}
