using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFG.RulesPenaltiesF1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HU23_01_Incidents_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Fine",
                table: "PenaltyType",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fine",
                table: "PenaltyType");
        }
    }
}
