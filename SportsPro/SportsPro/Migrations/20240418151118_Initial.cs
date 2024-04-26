using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsPro.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                column: "DateClosed",
                value: new DateTime(2024, 4, 18, 10, 11, 17, 842, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 3,
                column: "DateClosed",
                value: new DateTime(2024, 4, 18, 10, 11, 17, 842, DateTimeKind.Local).AddTicks(7032));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                column: "DateClosed",
                value: new DateTime(2024, 4, 5, 10, 15, 36, 663, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 3,
                column: "DateClosed",
                value: new DateTime(2024, 4, 5, 10, 15, 36, 663, DateTimeKind.Local).AddTicks(3921));
        }
    }
}
