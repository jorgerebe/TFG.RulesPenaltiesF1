using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFG.RulesPenaltiesF1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HU21_03_Incidents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Fine",
                table: "Incident",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LicensePoints",
                table: "Incident",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fine",
                table: "Incident");

            migrationBuilder.DropColumn(
                name: "LicensePoints",
                table: "Incident");
        }
    }
}
