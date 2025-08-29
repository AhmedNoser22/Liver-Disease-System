using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Liver_Disease_System.Migrations
{
    /// <inheritdoc />
    public partial class NewInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointment",
                columns: new[] { "Id", "AppointmentDate", "DoctorId", "Notes", "PatientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Follow-up visit", 1 },
                    { 2, new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Blood test", 2 },
                    { 3, new DateTime(2025, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Ultrasound check", 3 },
                    { 4, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Medication adjustment", 4 },
                    { 5, new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Chemotherapy session", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointment",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
