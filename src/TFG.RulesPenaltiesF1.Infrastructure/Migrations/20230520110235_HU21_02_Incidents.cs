using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFG.RulesPenaltiesF1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HU21_02_Incidents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incident_Competition_CompetitionId",
                table: "Incident");

            migrationBuilder.DropIndex(
                name: "IX_Incident_CompetitionId",
                table: "Incident");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "Incident");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetitionId",
                table: "Incident",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incident_CompetitionId",
                table: "Incident",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incident_Competition_CompetitionId",
                table: "Incident",
                column: "CompetitionId",
                principalTable: "Competition",
                principalColumn: "Id");
        }
    }
}
