using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lars_notedatabase.Migrations
{
    /// <inheritdoc />
    public partial class main : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instruments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(128)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1024)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contributors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    First_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Last_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1024)", nullable: false),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: true),
                    Birth_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Death_date = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contributors_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orchestral_sets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1024)", nullable: false),
                    Created_date = table.Column<DateTime>(type: "date", nullable: false),
                    Updated_date = table.Column<DateTime>(type: "date", nullable: false),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orchestral_sets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orchestral_sets_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContributorRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContributorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: true),
                    OrchestralSetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributorRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContributorRole_Contributors_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "Contributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContributorRole_Orchestral_sets_OrchestralSetId",
                        column: x => x.OrchestralSetId,
                        principalTable: "Orchestral_sets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Orchestral_set_id = table.Column<int>(type: "INTEGER", nullable: false),
                    File_path = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Upload_date = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    Actual_name = table.Column<string>(type: "VARCHAR(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Orchestral_sets_Orchestral_set_id",
                        column: x => x.Orchestral_set_id,
                        principalTable: "Orchestral_sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentOrchestralSet",
                columns: table => new
                {
                    OrchestralSetInstrumentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrchestralSetsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentOrchestralSet", x => new { x.OrchestralSetInstrumentsId, x.OrchestralSetsId });
                    table.ForeignKey(
                        name: "FK_InstrumentOrchestralSet_Instruments_OrchestralSetInstrumentsId",
                        column: x => x.OrchestralSetInstrumentsId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstrumentOrchestralSet_Orchestral_sets_OrchestralSetsId",
                        column: x => x.OrchestralSetsId,
                        principalTable: "Orchestral_sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    URL = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    OrchestralSetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_Orchestral_sets_OrchestralSetId",
                        column: x => x.OrchestralSetId,
                        principalTable: "Orchestral_sets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContributorRole_ContributorId",
                table: "ContributorRole",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContributorRole_OrchestralSetId",
                table: "ContributorRole",
                column: "OrchestralSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributors_CountryId",
                table: "Contributors",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_Orchestral_set_id",
                table: "Files",
                column: "Orchestral_set_id");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentOrchestralSet_OrchestralSetsId",
                table: "InstrumentOrchestralSet",
                column: "OrchestralSetsId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_OrchestralSetId",
                table: "Link",
                column: "OrchestralSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Orchestral_sets_CountryId",
                table: "Orchestral_sets",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContributorRole");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "InstrumentOrchestralSet");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropTable(
                name: "Contributors");

            migrationBuilder.DropTable(
                name: "Instruments");

            migrationBuilder.DropTable(
                name: "Orchestral_sets");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
