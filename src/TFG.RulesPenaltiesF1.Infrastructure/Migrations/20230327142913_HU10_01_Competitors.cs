using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFG.RulesPenaltiesF1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HU10_01_Competitors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TeamPrincipalID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PowerUnit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitor_AspNetUsers_TeamPrincipalID",
                        column: x => x.TeamPrincipalID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_TeamPrincipalID",
                table: "Competitor",
                column: "TeamPrincipalID",
                unique: true,
                filter: "[TeamPrincipalID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competitor");
        }
    }
}
