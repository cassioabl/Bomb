using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bomb.Infra.Data.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisarmAttempts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Result = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisarmAttempts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuttedWires",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColorEnum = table.Column<int>(type: "int", nullable: false),
                    DisarmAttemptId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttedWires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuttedWires_DisarmAttempts_DisarmAttemptId",
                        column: x => x.DisarmAttemptId,
                        principalTable: "DisarmAttempts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuttedWires_DisarmAttemptId",
                table: "CuttedWires",
                column: "DisarmAttemptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuttedWires");

            migrationBuilder.DropTable(
                name: "DisarmAttempts");
        }
    }
}
