using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFG.RulesPenaltiesF1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BUG02_01_LicensePointsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Penalty_NextCompetition_PenaltyTypeId",
                table: "Penalty");

            migrationBuilder.DropColumn(
                name: "NextCompetition",
                table: "Penalty");

            migrationBuilder.AddColumn<bool>(
                name: "Shown",
                table: "Penalty",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Penalty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_Type_PenaltyTypeId",
                table: "Penalty",
                columns: new[] { "Type", "PenaltyTypeId" },
                unique: true,
                filter: "[Type] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Penalty_Type_PenaltyTypeId",
                table: "Penalty");

            migrationBuilder.DropColumn(
                name: "Shown",
                table: "Penalty");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Penalty");

            migrationBuilder.AddColumn<bool>(
                name: "NextCompetition",
                table: "Penalty",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_NextCompetition_PenaltyTypeId",
                table: "Penalty",
                columns: new[] { "NextCompetition", "PenaltyTypeId" },
                unique: true,
                filter: "[NextCompetition] IS NOT NULL");
        }
    }
}
