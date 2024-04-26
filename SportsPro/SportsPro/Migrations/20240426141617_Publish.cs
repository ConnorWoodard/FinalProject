using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsPro.Migrations
{
    /// <inheritdoc />
    public partial class Publish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                column: "DateClosed",
                value: new DateTime(2024, 4, 26, 9, 16, 17, 95, DateTimeKind.Local).AddTicks(4864));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 3,
                column: "DateClosed",
                value: new DateTime(2024, 4, 26, 9, 16, 17, 95, DateTimeKind.Local).AddTicks(4872));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
