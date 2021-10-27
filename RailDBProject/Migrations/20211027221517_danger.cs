using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RailDBProject.Migrations
{
    public partial class danger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DangerousDefects",
                columns: table => new
                {
                    DangerousDefectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kilometer = table.Column<int>(type: "int", nullable: false),
                    Pkt = table.Column<int>(type: "int", nullable: false),
                    DateOfDetection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Path = table.Column<int>(type: "int", nullable: false),
                    WaySide = table.Column<int>(type: "int", nullable: false),
                    Manufacture = table.Column<int>(type: "int", nullable: false),
                    ManufactureYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DangerousDefectDepth = table.Column<double>(type: "float", nullable: false),
                    DangerousDefectLenght = table.Column<double>(type: "float", nullable: false),
                    DangerousDefectAverageDepth = table.Column<double>(type: "float", nullable: false),
                    DangerousDefectAverageLenght = table.Column<double>(type: "float", nullable: false),
                    DangerousDefectCode = table.Column<int>(type: "int", nullable: false),
                    DangerousDefectCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LocalSectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangerousDefects", x => x.DangerousDefectId);
                    table.ForeignKey(
                        name: "FK_DangerousDefects_LocalSections_LocalSectionId",
                        column: x => x.LocalSectionId,
                        principalTable: "LocalSections",
                        principalColumn: "LocalSectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangerousDefects_LocalSectionId",
                table: "DangerousDefects",
                column: "LocalSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangerousDefects");
        }
    }
}
