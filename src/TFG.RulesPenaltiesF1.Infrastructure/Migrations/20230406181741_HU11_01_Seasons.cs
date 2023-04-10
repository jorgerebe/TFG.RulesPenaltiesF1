using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFG.RulesPenaltiesF1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HU11_01_Seasons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    RegulationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Season_Regulation_RegulationId",
                        column: x => x.RegulationId,
                        principalTable: "Regulation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    CircuitId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSprint = table.Column<bool>(type: "bit", nullable: false),
                    Week = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competition_Circuit_CircuitId",
                        column: x => x.CircuitId,
                        principalTable: "Circuit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Competition_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeasonCompetitor",
                columns: table => new
                {
                    CompetitorsId = table.Column<int>(type: "int", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonCompetitor", x => new { x.CompetitorsId, x.SeasonId });
                    table.ForeignKey(
                        name: "FK_SeasonCompetitor_Competitor_CompetitorsId",
                        column: x => x.CompetitorsId,
                        principalTable: "Competitor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeasonCompetitor_Season_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competition_CircuitId",
                table: "Competition",
                column: "CircuitId");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_SeasonId",
                table: "Competition",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Competition_Week_SeasonId",
                table: "Competition",
                columns: new[] { "Week", "SeasonId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Season_RegulationId",
                table: "Season",
                column: "RegulationId");

            migrationBuilder.CreateIndex(
                name: "IX_Season_Year",
                table: "Season",
                column: "Year",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeasonCompetitor_SeasonId",
                table: "SeasonCompetitor",
                column: "SeasonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "SeasonCompetitor");

            migrationBuilder.DropTable(
                name: "Season");
        }
    }
}
