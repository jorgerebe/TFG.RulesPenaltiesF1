using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFG.RulesPenaltiesF1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HU21_01_Incidents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Participation",
                table: "Participation");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Participation",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participation",
                table: "Participation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Incident",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParticipationId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    Fact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    PenaltyId = table.Column<int>(type: "int", nullable: false),
                    CompetitionId = table.Column<int>(type: "int", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incident", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incident_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incident_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Incident_Participation_ParticipationId",
                        column: x => x.ParticipationId,
                        principalTable: "Participation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incident_Penalty_PenaltyId",
                        column: x => x.PenaltyId,
                        principalTable: "Penalty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incident_Session_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Session",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participation_DriverId_CompetitionId_CompetitorId",
                table: "Participation",
                columns: new[] { "DriverId", "CompetitionId", "CompetitorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incident_ArticleId",
                table: "Incident",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_CompetitionId",
                table: "Incident",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_ParticipationId",
                table: "Incident",
                column: "ParticipationId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_PenaltyId",
                table: "Incident",
                column: "PenaltyId");

            migrationBuilder.CreateIndex(
                name: "IX_Incident_SessionId",
                table: "Incident",
                column: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incident");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participation",
                table: "Participation");

            migrationBuilder.DropIndex(
                name: "IX_Participation_DriverId_CompetitionId_CompetitorId",
                table: "Participation");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Participation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participation",
                table: "Participation",
                columns: new[] { "DriverId", "CompetitionId", "CompetitorId" });
        }
    }
}
