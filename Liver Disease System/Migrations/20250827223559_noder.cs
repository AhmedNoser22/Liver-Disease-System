using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Liver_Disease_System.Migrations
{
    /// <inheritdoc />
    public partial class noder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicine_Medicine_MedicineId",
                table: "PatientMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMedicine_Patient_PatientId",
                table: "PatientMedicine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientMedicine",
                table: "PatientMedicine");

            migrationBuilder.RenameTable(
                name: "PatientMedicine",
                newName: "patientMedicine");

            migrationBuilder.RenameIndex(
                name: "IX_PatientMedicine_MedicineId",
                table: "patientMedicine",
                newName: "IX_patientMedicine_MedicineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_patientMedicine",
                table: "patientMedicine",
                columns: new[] { "PatientId", "MedicineId" });

            migrationBuilder.AddForeignKey(
                name: "FK_patientMedicine_Medicine_MedicineId",
                table: "patientMedicine",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patientMedicine_Patient_PatientId",
                table: "patientMedicine",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patientMedicine_Medicine_MedicineId",
                table: "patientMedicine");

            migrationBuilder.DropForeignKey(
                name: "FK_patientMedicine_Patient_PatientId",
                table: "patientMedicine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_patientMedicine",
                table: "patientMedicine");

            migrationBuilder.RenameTable(
                name: "patientMedicine",
                newName: "PatientMedicine");

            migrationBuilder.RenameIndex(
                name: "IX_patientMedicine_MedicineId",
                table: "PatientMedicine",
                newName: "IX_PatientMedicine_MedicineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientMedicine",
                table: "PatientMedicine",
                columns: new[] { "PatientId", "MedicineId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicine_Medicine_MedicineId",
                table: "PatientMedicine",
                column: "MedicineId",
                principalTable: "Medicine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMedicine_Patient_PatientId",
                table: "PatientMedicine",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
