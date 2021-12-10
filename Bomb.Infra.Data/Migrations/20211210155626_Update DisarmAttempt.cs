using Microsoft.EntityFrameworkCore.Migrations;

namespace Bomb.Infra.Data.Migrations
{
    public partial class UpdateDisarmAttempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Result",
                table: "DisarmAttempts",
                newName: "Success");

            migrationBuilder.AlterColumn<string>(
                name: "ColorEnum",
                table: "CuttedWires",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Success",
                table: "DisarmAttempts",
                newName: "Result");

            migrationBuilder.AlterColumn<int>(
                name: "ColorEnum",
                table: "CuttedWires",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
