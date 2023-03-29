using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TFG.RulesPenaltiesF1.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HU09_04_Circuits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Laps",
                table: "Circuit",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Laps",
                table: "Circuit",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
