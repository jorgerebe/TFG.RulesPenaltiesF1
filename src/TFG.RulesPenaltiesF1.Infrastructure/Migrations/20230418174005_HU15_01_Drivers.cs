using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFG.RulesPenaltiesF1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HU15_01_Drivers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicensePoints = table.Column<int>(type: "int", nullable: false),
                    CompetitorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Driver_Competitor_CompetitorId",
                        column: x => x.CompetitorId,
                        principalTable: "Competitor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Driver_CompetitorId",
                table: "Driver",
                column: "CompetitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_Name",
                table: "Driver",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Driver");
        }
    }
}
