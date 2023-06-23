using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFG.RulesPenaltiesF1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HU19_Participations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finished",
                table: "Session");

            migrationBuilder.RenameColumn(
                name: "CompetitionState",
                table: "Competition",
                newName: "State");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Session",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Participation",
                columns: table => new
                {
                    CompetitionId = table.Column<int>(type: "int", nullable: false),
                    CompetitorId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participation", x => new { x.DriverId, x.CompetitionId, x.CompetitorId });
                    table.ForeignKey(
                        name: "FK_Participation_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participation_Competitor_CompetitorId",
                        column: x => x.CompetitorId,
                        principalTable: "Competitor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participation_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participation_CompetitionId",
                table: "Participation",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_CompetitorId",
                table: "Participation",
                column: "CompetitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Session");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Competition",
                newName: "CompetitionState");

            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "Session",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
