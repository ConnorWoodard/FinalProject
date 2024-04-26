﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsPro.Models.DomainModels;

#nullable disable

namespace SportsPro.Migrations
{
    [DbContext(typeof(SportsContext))]
    [Migration("20240426134745_Customers")]
    partial class Customers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CustomerProducts", b =>
                {
                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("CustomersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CustomerProducts");

                    b.HasData(
                        new
                        {
                            CustomersId = 1,
                            ProductsId = 1
                        },
                        new
                        {
                            CustomersId = 1,
                            ProductsId = 2
                        },
                        new
                        {
                            CustomersId = 2,
                            ProductsId = 2
                        },
                        new
                        {
                            CustomersId = 3,
                            ProductsId = 3
                        },
                        new
                        {
                            CustomersId = 4,
                            ProductsId = 3
                        },
                        new
                        {
                            CustomersId = 4,
                            ProductsId = 5
                        },
                        new
                        {
                            CustomersId = 5,
                            ProductsId = 8
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SportsPro.Models.DomainModels.Country", b =>
                {
                    b.Property<int?>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CountryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Name = "USA"
                        },
                        new
                        {
                            CountryId = 2,
                            Name = "Canada"
                        },
                        new
                        {
                            CountryId = 3,
                            Name = "England"
                        },
                        new
                        {
                            CountryId = 4,
                            Name = "France"
                        },
                        new
                        {
                            CountryId = 5,
                            Name = "Germany"
                        },
                        new
                        {
                            CountryId = 6,
                            Name = "Italy"
                        },
                        new
                        {
                            CountryId = 7,
                            Name = "Spain"
                        },
                        new
                        {
                            CountryId = 8,
                            Name = "Mexico"
                        },
                        new
                        {
                            CountryId = 9,
                            Name = "Brazil"
                        },
                        new
                        {
                            CountryId = 10,
                            Name = "Argentina"
                        });
                });

            modelBuilder.Entity("SportsPro.Models.DomainModels.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "123 Elm St",
                            City = "Toronto",
                            CountryId = 2,
                            Email = "johndoe@sportsprosoftware.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Phone = "800-565-0443",
                            PostalCode = "M1M1M1",
                            State = "ON"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "456 Oak St",
                            City = "Vancouver",
                            CountryId = 2,
                            Email = "smith523@sportsprosoftware.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            Phone = "810-565-0443",
                            PostalCode = "V5V 5V5",
                            State = "BC"
                        },
                        new
                        {
                            CustomerId = 3,
                            Address = "789 Pine St",
                            City = "Montreal",
                            CountryId = 2,
                            Email = "quebeclover12@sportsprosoftware.com",
                            FirstName = "Mike",
                            LastName = "Jones",
                            Phone = "820-565-0443",
                            PostalCode = "H3H 3H3",
                            State = "QC"
                        },
                        new
                        {
                            CustomerId = 4,
                            Address = "1010 Birch St",
                            City = "San Francisco",
                            CountryId = 1,
                            Email = "kanthoni@gmail.com",
                            FirstName = "Kaitlyn",
                            LastName = "Anthoni",
                            Phone = "830-565-0578",
                            PostalCode = "94101",
                            State = "CA"
                        },
                        new
                        {
                            CustomerId = 5,
                            Address = "1111 Cedar St",
                            City = "Los Angeles",
                            CountryId = 1,
                            Email = "",
                            FirstName = "Karl",
                            LastName = "Bronsom",
                            Phone = "",
                            PostalCode = "90001",
                            State = "CA"
                        });
                });

            modelBuilder.Entity("SportsPro.Models.DomainModels.Incidents", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncidentId"));

                    b.Property<int?>("CustomerId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("ProductId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IncidentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CustomerId = 1,
                            DateOpened = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Received error code 123 when trying to install",
                            ProductId = 1,
                            TechnicianId = 1,
                            Title = "Could not install"
                        },
                        new
                        {
                            IncidentId = 2,
                            CustomerId = 2,
                            DateClosed = new DateTime(2024, 4, 26, 8, 47, 44, 731, DateTimeKind.Local).AddTicks(2653),
                            DateOpened = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Received error code 123 when trying to install",
                            ProductId = 2,
                            TechnicianId = 2,
                            Title = "Could not install"
                        },
                        new
                        {
                            IncidentId = 3,
                            CustomerId = 5,
                            DateClosed = new DateTime(2024, 4, 26, 8, 47, 44, 731, DateTimeKind.Local).AddTicks(2662),
                            DateOpened = new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Program fails with error code 510, unable to open database.",
                            ProductId = 8,
                            TechnicianId = 3,
                            Title = "Error launching program"
                        },
                        new
                        {
                            IncidentId = 4,
                            CustomerId = 4,
                            DateOpened = new DateTime(2022, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Program fails with error code 510, unable to open database.",
                            ProductId = 7,
                            TechnicianId = 4,
                            Title = "Error launching program"
                        });
                });

            modelBuilder.Entity("SportsPro.Models.DomainModels.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("YearlyPrice")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Tournament Master 1.0",
                            ProductCode = "TRNY10",
                            ReleaseDate = new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 4.99m
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "League Scheduler 1.0",
                            ProductCode = "LEAG10",
                            ReleaseDate = new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 4.99m
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "Team Manager 1.0",
                            ProductCode = "TEAM10",
                            ReleaseDate = new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 4.99m
                        },
                        new
                        {
                            ProductId = 4,
                            Name = "Tournament Master 1.1",
                            ProductCode = "TRNY11",
                            ReleaseDate = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 5.99m
                        },
                        new
                        {
                            ProductId = 5,
                            Name = "League Scheduler 1.1",
                            ProductCode = "LEAG11",
                            ReleaseDate = new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 5.99m
                        },
                        new
                        {
                            ProductId = 6,
                            Name = "Team Manager 1.1",
                            ProductCode = "TEAM11",
                            ReleaseDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 5.99m
                        },
                        new
                        {
                            ProductId = 7,
                            Name = "Tournament Master 2.0",
                            ProductCode = "TRNY20",
                            ReleaseDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 8.99m
                        },
                        new
                        {
                            ProductId = 8,
                            Name = "League Scheduler 2.0",
                            ProductCode = "LEAG20",
                            ReleaseDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 8.99m
                        },
                        new
                        {
                            ProductId = 9,
                            Name = "Team Manager 2.0",
                            ProductCode = "TEAM20",
                            ReleaseDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            YearlyPrice = 8.99m
                        });
                });

            modelBuilder.Entity("SportsPro.Models.DomainModels.Technicians", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnicianId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = -1,
                            Email = "na@gmail.com",
                            Name = "Not assigned",
                            Phone = "111-111-1111"
                        },
                        new
                        {
                            TechnicianId = 1,
                            Email = "alison@sportsprosoftware.com",
                            Name = "Alison Diaz",
                            Phone = "800-555-0443"
                        },
                        new
                        {
                            TechnicianId = 2,
                            Email = "adeyoung@sportsprosoftware.com",
                            Name = "Allan Deyoung",
                            Phone = "800-555-5555"
                        },
                        new
                        {
                            TechnicianId = 3,
                            Email = "ddouglas@gmai.com",
                            Name = "Drew Douglas",
                            Phone = "800-555-0423"
                        },
                        new
                        {
                            TechnicianId = 4,
                            Email = "gunter@sportsprosoftware.com",
                            Name = "Gunter Wendt",
                            Phone = "800-555-0453"
                        },
                        new
                        {
                            TechnicianId = 5,
                            Email = "jwilson23@sportsprosoftware.com",
                            Name = "Jim Wilson",
                            Phone = "800-555-0449"
                        });
                });

            modelBuilder.Entity("SportsPro.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CustomerProducts", b =>
                {
                    b.HasOne("SportsPro.Models.DomainModels.Customers", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsPro.Models.DomainModels.Products", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SportsPro.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SportsPro.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsPro.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SportsPro.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SportsPro.Models.DomainModels.Customers", b =>
                {
                    b.HasOne("SportsPro.Models.DomainModels.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("SportsPro.Models.DomainModels.Incidents", b =>
                {
                    b.HasOne("SportsPro.Models.DomainModels.Customers", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsPro.Models.DomainModels.Products", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsPro.Models.DomainModels.Technicians", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });
#pragma warning restore 612, 618
        }
    }
}
