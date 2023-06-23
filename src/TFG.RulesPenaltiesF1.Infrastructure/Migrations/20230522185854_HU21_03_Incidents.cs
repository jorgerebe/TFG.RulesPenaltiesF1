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
            migrationBuilder.DropForeignKey(
                name: "FK_Incident_Penalty_PenaltyId",
                table: "Incident");

            migrationBuilder.AlterColumn<int>(
                name: "PenaltyId",
                table: "Incident",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_Penalty_PenaltyId",
                table: "Incident",
                column: "PenaltyId",
                principalTable: "Penalty",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incident_Penalty_PenaltyId",
                table: "Incident");

            migrationBuilder.DropColumn(
                name: "Fine",
                table: "Incident");

            migrationBuilder.DropColumn(
                name: "LicensePoints",
                table: "Incident");

            migrationBuilder.AlterColumn<int>(
                name: "PenaltyId",
                table: "Incident",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_Penalty_PenaltyId",
                table: "Incident",
                column: "PenaltyId",
                principalTable: "Penalty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
