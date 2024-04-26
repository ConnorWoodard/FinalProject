using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsPro.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 2,
                column: "DateClosed",
                value: new DateTime(2024, 4, 18, 10, 11, 52, 585, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "IncidentId",
                keyValue: 3,
                column: "DateClosed",
                value: new DateTime(2024, 4, 18, 10, 11, 52, 585, DateTimeKind.Local).AddTicks(7648));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
