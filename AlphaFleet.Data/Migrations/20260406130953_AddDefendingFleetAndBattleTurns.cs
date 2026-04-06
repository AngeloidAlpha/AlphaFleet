using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDefendingFleetAndBattleTurns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DefendingFleetId",
                table: "Battles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TurnsPlayed",
                table: "Battles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BattleTurns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BattleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurnNumber = table.Column<int>(type: "int", nullable: false),
                    DamageDealt = table.Column<int>(type: "int", nullable: false),
                    DefenderRemainingHealth = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleTurns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleTurns_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Battles",
                keyColumn: "Id",
                keyValue: new Guid("f1e2d3c4-b5a6-7890-1234-56789abcdef0"),
                columns: new[] { "DefendingFleetId", "TurnsPlayed" },
                values: new object[] { new Guid("4241c74f-092c-4249-b731-954fb7658830"), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Battles_DefendingFleetId",
                table: "Battles",
                column: "DefendingFleetId");

            migrationBuilder.CreateIndex(
                name: "IX_BattleTurns_BattleId",
                table: "BattleTurns",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Battles_Fleets_DefendingFleetId",
                table: "Battles",
                column: "DefendingFleetId",
                principalTable: "Fleets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Battles_Fleets_DefendingFleetId",
                table: "Battles");

            migrationBuilder.DropTable(
                name: "BattleTurns");

            migrationBuilder.DropIndex(
                name: "IX_Battles_DefendingFleetId",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "DefendingFleetId",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "TurnsPlayed",
                table: "Battles");
        }
    }
}
