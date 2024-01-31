using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SportsPro.Migrations
{
    /// <inheritdoc />
    public partial class ProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    YearlyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "ProductCode", "ReleaseDate", "YearlyPrice" },
                values: new object[,]
                {
                    { 1, "Tournament Master 1.0", "TRNY10", "2015-01-01", 4.99m },
                    { 2, "League Scheduler 1.0", "LEAG10", "2016-01-01", 4.99m },
                    { 3, "Team Manager 1.0", "TEAM10", "2017-01-01", 4.99m },
                    { 4, "Tournament Master 1.1", "TRNY11", "2018-01-01", 5.99m },
                    { 5, "League Scheduler 1.1", "LEAG11", "2019-01-01", 5.99m },
                    { 6, "Team Manager 1.1", "TEAM11", "2020-01-01", 5.99m },
                    { 7, "Tournament Master 2.0", "TRNY20", "2021-01-01", 8.99m },
                    { 8, "League Scheduler 2.0", "LEAG20", "2021-01-01", 8.99m },
                    { 9, "Team Manager 2.0", "TEAM20", "2021-01-01", 8.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
