using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFG.RulesPenaltiesF1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HU03_03_04_RegulationArticlesAndPenalties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Regulation");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Regulation",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "RegulationPenalty",
                columns: table => new
                {
                    RegulationId = table.Column<int>(type: "int", nullable: false),
                    PenaltyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegulationPenalty", x => new { x.RegulationId, x.PenaltyId });
                    table.ForeignKey(
                        name: "FK_RegulationPenalty_Penalty_PenaltyId",
                        column: x => x.PenaltyId,
                        principalTable: "Penalty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegulationPenalty_Regulation_RegulationId",
                        column: x => x.RegulationId,
                        principalTable: "Regulation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Regulation_Name",
                table: "Regulation",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegulationPenalty_PenaltyId_RegulationId",
                table: "RegulationPenalty",
                columns: new[] { "PenaltyId", "RegulationId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegulationPenalty");

            migrationBuilder.DropIndex(
                name: "IX_Regulation_Name",
                table: "Regulation");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Regulation");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Regulation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
