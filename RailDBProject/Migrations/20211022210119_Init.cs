using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RailDBProject.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GlobalSections",
                columns: table => new
                {
                    GlobalSectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlobalSectionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GlobalWayNumber = table.Column<int>(type: "int", nullable: false),
                    OrganisationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalSections", x => x.GlobalSectId);
                });

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    OrganisationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrgName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    OrganisationRole = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ParentOrganisationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.OrganisationId);
                    table.ForeignKey(
                        name: "FK_Organisations_Organisations_ParentOrganisationId",
                        column: x => x.ParentOrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Defectoscopes",
                columns: table => new
                {
                    DefectoScopeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<int>(type: "int", nullable: false),
                    DefectoScopeType = table.Column<int>(type: "int", nullable: false),
                    LastMaintenansProcedure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefectoScopeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganisationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defectoscopes", x => x.DefectoScopeId);
                    table.ForeignKey(
                        name: "FK_Defectoscopes_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GlobalSectionOrganisation",
                columns: table => new
                {
                    GlobalSectionsGlobalSectId = table.Column<int>(type: "int", nullable: false),
                    OrganisationsOrganisationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalSectionOrganisation", x => new { x.GlobalSectionsGlobalSectId, x.OrganisationsOrganisationId });
                    table.ForeignKey(
                        name: "FK_GlobalSectionOrganisation_GlobalSections_GlobalSectionsGlobalSectId",
                        column: x => x.GlobalSectionsGlobalSectId,
                        principalTable: "GlobalSections",
                        principalColumn: "GlobalSectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GlobalSectionOrganisation_Organisations_OrganisationsOrganisationId",
                        column: x => x.OrganisationsOrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalSections",
                columns: table => new
                {
                    LocalSectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalSectionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocalWayNumber = table.Column<int>(type: "int", nullable: false),
                    GlobalSectionGlobalSectId = table.Column<int>(type: "int", nullable: true),
                    OrganisationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalSections", x => x.LocalSectionId);
                    table.ForeignKey(
                        name: "FK_LocalSections_GlobalSections_GlobalSectionGlobalSectId",
                        column: x => x.GlobalSectionGlobalSectId,
                        principalTable: "GlobalSections",
                        principalColumn: "GlobalSectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalSections_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganisationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    OperatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Qualification = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastQualificationTraning = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DismissalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganisationId = table.Column<int>(type: "int", nullable: true),
                    DefectoScopeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.OperatorId);
                    table.ForeignKey(
                        name: "FK_Operators_Defectoscopes_DefectoScopeId",
                        column: x => x.DefectoScopeId,
                        principalTable: "Defectoscopes",
                        principalColumn: "DefectoScopeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operators_Organisations_OrganisationId",
                        column: x => x.OrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Defects",
                columns: table => new
                {
                    DefectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kilometer = table.Column<int>(type: "int", nullable: false),
                    Pkt = table.Column<int>(type: "int", nullable: false),
                    DateOfDetection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Path = table.Column<int>(type: "int", nullable: false),
                    WaySide = table.Column<int>(type: "int", nullable: false),
                    Manufacture = table.Column<int>(type: "int", nullable: false),
                    ManufactureYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefectDepth = table.Column<double>(type: "float", nullable: false),
                    DefectLenght = table.Column<double>(type: "float", nullable: false),
                    DefectCode = table.Column<int>(type: "int", nullable: false),
                    DefectCodeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LocalSectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defects", x => x.DefectId);
                    table.ForeignKey(
                        name: "FK_Defects_LocalSections_LocalSectionId",
                        column: x => x.LocalSectionId,
                        principalTable: "LocalSections",
                        principalColumn: "LocalSectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Defectoscopes_OrganisationId",
                table: "Defectoscopes",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Defects_LocalSectionId",
                table: "Defects",
                column: "LocalSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalSectionOrganisation_OrganisationsOrganisationId",
                table: "GlobalSectionOrganisation",
                column: "OrganisationsOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalSections_GlobalSectionGlobalSectId",
                table: "LocalSections",
                column: "GlobalSectionGlobalSectId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalSections_OrganisationId",
                table: "LocalSections",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_DefectoScopeId",
                table: "Operators",
                column: "DefectoScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_OrganisationId",
                table: "Operators",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_ParentOrganisationId",
                table: "Organisations",
                column: "ParentOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganisationId",
                table: "Users",
                column: "OrganisationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Defects");

            migrationBuilder.DropTable(
                name: "GlobalSectionOrganisation");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LocalSections");

            migrationBuilder.DropTable(
                name: "Defectoscopes");

            migrationBuilder.DropTable(
                name: "GlobalSections");

            migrationBuilder.DropTable(
                name: "Organisations");
        }
    }
}
