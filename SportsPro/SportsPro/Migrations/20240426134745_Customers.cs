using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsPro.Migrations
{
    /// <inheritdoc />
    public partial class Customers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                column: "DateClosed",
                value: new DateTime(2024, 4, 26, 8, 47, 44, 731, DateTimeKind.Local).AddTicks(2653));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 3,
                column: "DateClosed",
                value: new DateTime(2024, 4, 26, 8, 47, 44, 731, DateTimeKind.Local).AddTicks(2662));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                column: "DateClosed",
                value: new DateTime(2024, 4, 18, 20, 8, 4, 775, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 3,
                column: "DateClosed",
                value: new DateTime(2024, 4, 18, 20, 8, 4, 775, DateTimeKind.Local).AddTicks(7474));
        }
    }
}
