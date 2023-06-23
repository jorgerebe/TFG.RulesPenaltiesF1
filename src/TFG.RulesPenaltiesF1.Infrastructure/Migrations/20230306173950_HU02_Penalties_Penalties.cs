using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFG.RulesPenaltiesF1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HU02PenalizacionesPenalties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Penalty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PenaltyTypeId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextCompetition = table.Column<bool>(type: "bit", nullable: true),
                    ElapsedSeconds = table.Column<int>(type: "int", nullable: true),
                    Seconds = table.Column<int>(type: "int", nullable: true),
                    Positions = table.Column<int>(type: "int", nullable: true),
                    DrivingReprimand = table.Column<bool>(type: "bit", nullable: true),
                    TimePenalty_Seconds = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Penalty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Penalty_PenaltyType_PenaltyTypeId",
                        column: x => x.PenaltyTypeId,
                        principalTable: "PenaltyType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_DrivingReprimand_PenaltyTypeId",
                table: "Penalty",
                columns: new[] { "DrivingReprimand", "PenaltyTypeId" },
                unique: true,
                filter: "[DrivingReprimand] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_ElapsedSeconds_PenaltyTypeId",
                table: "Penalty",
                columns: new[] { "ElapsedSeconds", "PenaltyTypeId" },
                unique: true,
                filter: "[ElapsedSeconds] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_ElapsedSeconds_Seconds_PenaltyTypeId",
                table: "Penalty",
                columns: new[] { "ElapsedSeconds", "Seconds", "PenaltyTypeId" },
                unique: true,
                filter: "[ElapsedSeconds] IS NOT NULL AND [Seconds] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_NextCompetition_PenaltyTypeId",
                table: "Penalty",
                columns: new[] { "NextCompetition", "PenaltyTypeId" },
                unique: true,
                filter: "[NextCompetition] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_PenaltyTypeId",
                table: "Penalty",
                column: "PenaltyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_Positions_PenaltyTypeId",
                table: "Penalty",
                columns: new[] { "Positions", "PenaltyTypeId" },
                unique: true,
                filter: "[Positions] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Penalty_TimePenalty_Seconds_PenaltyTypeId",
                table: "Penalty",
                columns: new[] { "TimePenalty_Seconds", "PenaltyTypeId" },
                unique: true,
                filter: "[Seconds] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Penalty");
        }
    }
}
