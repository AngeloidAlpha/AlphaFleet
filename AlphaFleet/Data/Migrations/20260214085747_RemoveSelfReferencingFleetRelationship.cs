using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSelfReferencingFleetRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fleets_Fleets_FleetId",
                table: "Fleets");

            migrationBuilder.DropIndex(
                name: "IX_Fleets_FleetId",
                table: "Fleets");

            migrationBuilder.DropColumn(
                name: "FleetId",
                table: "Fleets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FleetId",
                table: "Fleets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fleets_FleetId",
                table: "Fleets",
                column: "FleetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fleets_Fleets_FleetId",
                table: "Fleets",
                column: "FleetId",
                principalTable: "Fleets",
                principalColumn: "Id");
        }
    }
}
