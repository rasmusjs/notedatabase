using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lars_notedatabase.Migrations
{
    /// <inheritdoc />
    public partial class DBMigration0106 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentOrchestralSet_Instruments_OrchestralSetInstrumentsId",
                table: "InstrumentOrchestralSet");

            migrationBuilder.DropForeignKey(
                name: "FK_InstrumentOrchestralSet_Orchestral_sets_OrchestralSetsId",
                table: "InstrumentOrchestralSet");

            migrationBuilder.DropTable(
                name: "ContributorRole");

            migrationBuilder.DropTable(
                name: "Link");

            migrationBuilder.DropIndex(
                name: "IX_InstrumentOrchestralSet_OrchestralSetsId",
                table: "InstrumentOrchestralSet");

            migrationBuilder.RenameColumn(
                name: "OrchestralSetsId",
                table: "InstrumentOrchestralSet",
                newName: "InstrumentsId");

            migrationBuilder.RenameColumn(
                name: "OrchestralSetInstrumentsId",
                table: "InstrumentOrchestralSet",
                newName: "InstrumentId");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Orchestral_sets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "ContributorRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContributorId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrchestralSetId = table.Column<int>(type: "INTEGER", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributorRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContributorRoles_Contributors_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "Contributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContributorRoles_Orchestral_sets_OrchestralSetId",
                        column: x => x.OrchestralSetId,
                        principalTable: "Orchestral_sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    URL = table.Column<string>(type: "TEXT", nullable: false),
                    OrchestralSetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Orchestral_sets_OrchestralSetId",
                        column: x => x.OrchestralSetId,
                        principalTable: "Orchestral_sets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrchestralSetInstrument",
                columns: table => new
                {
                    OrchestralSetId = table.Column<int>(type: "INTEGER", nullable: false),
                    InstrumentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrchestralSetInstrument", x => new { x.OrchestralSetId, x.InstrumentId });
                    table.ForeignKey(
                        name: "FK_OrchestralSetInstrument_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrchestralSetInstrument_OrchestralSetId",
                        column: x => x.OrchestralSetId,
                        principalTable: "Orchestral_sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContributorRoles_ContributorId",
                table: "ContributorRoles",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContributorRoles_OrchestralSetId",
                table: "ContributorRoles",
                column: "OrchestralSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_OrchestralSetId",
                table: "Links",
                column: "OrchestralSetId");

            migrationBuilder.CreateIndex(
                name: "IX_OrchestralSetInstrument_InstrumentId",
                table: "OrchestralSetInstrument",
                column: "InstrumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContributorRoles");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "OrchestralSetInstrument");

            migrationBuilder.RenameColumn(
                name: "InstrumentsId",
                table: "InstrumentOrchestralSet",
                newName: "OrchestralSetsId");

            migrationBuilder.RenameColumn(
                name: "InstrumentId",
                table: "InstrumentOrchestralSet",
                newName: "OrchestralSetInstrumentsId");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Orchestral_sets",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ContributorRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContributorId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrchestralSetId = table.Column<int>(type: "INTEGER", nullable: true),
                    Role = table.Column<int>(type: "INTEGER", nullable: true)
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
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    OrchestralSetId = table.Column<int>(type: "INTEGER", nullable: true),
                    URL = table.Column<string>(type: "TEXT", nullable: false)
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
                name: "IX_InstrumentOrchestralSet_OrchestralSetsId",
                table: "InstrumentOrchestralSet",
                column: "OrchestralSetsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContributorRole_ContributorId",
                table: "ContributorRole",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContributorRole_OrchestralSetId",
                table: "ContributorRole",
                column: "OrchestralSetId");

            migrationBuilder.CreateIndex(
                name: "IX_Link_OrchestralSetId",
                table: "Link",
                column: "OrchestralSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentOrchestralSet_Instruments_OrchestralSetInstrumentsId",
                table: "InstrumentOrchestralSet",
                column: "OrchestralSetInstrumentsId",
                principalTable: "Instruments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InstrumentOrchestralSet_Orchestral_sets_OrchestralSetsId",
                table: "InstrumentOrchestralSet",
                column: "OrchestralSetsId",
                principalTable: "Orchestral_sets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
