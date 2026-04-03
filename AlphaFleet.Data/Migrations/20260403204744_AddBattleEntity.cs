using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBattleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttackingFleetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefendingStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Outcome = table.Column<int>(type: "int", nullable: false),
                    DamageDealt = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battles_Fleets_AttackingFleetId",
                        column: x => x.AttackingFleetId,
                        principalTable: "Fleets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Battles_Stations_DefendingStationId",
                        column: x => x.DefendingStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Battles",
                columns: new[] { "Id", "AttackingFleetId", "DamageDealt", "DefendingStationId", "Description", "EndTime", "Outcome", "StartTime" },
                values: new object[] { new Guid("f1e2d3c4-b5a6-7890-1234-56789abcdef0"), new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), 2500, new Guid("a1b2c3d4-e5f6-7890-1234-56789abcdef0"), "Alpha Fleet successfully captured Orion Outpost.", new DateTime(2026, 4, 1, 14, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2026, 4, 1, 12, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.CreateIndex(
                name: "IX_Battles_AttackingFleetId",
                table: "Battles",
                column: "AttackingFleetId");

            migrationBuilder.CreateIndex(
                name: "IX_Battles_DefendingStationId",
                table: "Battles",
                column: "DefendingStationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Battles");
        }
    }
}
