using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthHub.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_SpecialistModel_SpecialistModelSpecialistId",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecialistModel",
                table: "SpecialistModel");

            migrationBuilder.RenameTable(
                name: "SpecialistModel",
                newName: "Specialist");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialist",
                table: "Specialist",
                column: "SpecialistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialist_SpecialistModelSpecialistId",
                table: "Doctors",
                column: "SpecialistModelSpecialistId",
                principalTable: "Specialist",
                principalColumn: "SpecialistId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialist_SpecialistModelSpecialistId",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialist",
                table: "Specialist");

            migrationBuilder.RenameTable(
                name: "Specialist",
                newName: "SpecialistModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecialistModel",
                table: "SpecialistModel",
                column: "SpecialistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_SpecialistModel_SpecialistModelSpecialistId",
                table: "Doctors",
                column: "SpecialistModelSpecialistId",
                principalTable: "SpecialistModel",
                principalColumn: "SpecialistId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
