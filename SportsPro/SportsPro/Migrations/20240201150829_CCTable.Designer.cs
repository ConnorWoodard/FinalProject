﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsPro.Models;

#nullable disable

namespace SportsPro.Migrations
{
    [DbContext(typeof(SportsContext))]
    [Migration("20240201150829_CCTable")]
    partial class CCTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SportsPro.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"));

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

            modelBuilder.Entity("SportsPro.Models.Customers", b =>
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
                        .IsRequired()
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
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

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

            modelBuilder.Entity("SportsPro.Models.Products", b =>
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

            modelBuilder.Entity("SportsPro.Models.Technicians", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnicianId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
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

            modelBuilder.Entity("SportsPro.Models.Customers", b =>
                {
                    b.HasOne("SportsPro.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}
