using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddShipStatsAndBattleUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Attack",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Defense",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Health",
                table: "Ships",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("3b12f1b5-981a-4d72-804b-ae15c78264ab"),
                columns: new[] { "Attack", "Defense", "Health" },
                values: new object[] { 10, 1, 50 });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("9c4e6f2a-7d38-4e5b-b120-df6a41c8e9c7"),
                columns: new[] { "Attack", "Defense", "Health" },
                values: new object[] { 10, 1, 50 });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("d5a83f4e-2b17-49c6-a8e3-7f1d9b05c42e"),
                columns: new[] { "Attack", "Defense", "Health" },
                values: new object[] { 10, 1, 50 });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("e72b4a19-6c5d-4f83-91a2-8d3e0b7fc56a"),
                columns: new[] { "Attack", "Defense", "Health" },
                values: new object[] { 10, 1, 50 });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                columns: new[] { "Attack", "Defense", "Health" },
                values: new object[] { 10, 1, 50 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attack",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "Defense",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "Health",
                table: "Ships");
        }
    }
}
