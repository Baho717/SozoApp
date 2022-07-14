using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SozoApothecary.Migrations
{
    public partial class removedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicationAmount",
                table: "MedicationHistories");

            migrationBuilder.DropColumn(
                name: "MedicationAmount",
                table: "CurrentMedications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicationAmount",
                table: "MedicationHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicationAmount",
                table: "CurrentMedications",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
