using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlphaFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialShipsAndFleets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Ships",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Fleets",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("1ad72291-5fa1-4744-9db8-19a382b269fd"), "Orpheus Station", "Kappa Division" },
                    { new Guid("4241c74f-092c-4249-b731-954fb7658830"), "Orion Outpost", "Beta Squadron" },
                    { new Guid("44dee55a-f48f-419f-884b-943355bbde32"), "Sirius Gate", "Epsilon Armada" },
                    { new Guid("596dc552-0964-4298-baa7-34bee5b255b3"), "Delta Quadrant", "Theta Squadron" },
                    { new Guid("6c6294c1-d329-4240-9620-d4bebed89fd3"), "Laniakea Hub", "Iota Fleet" },
                    { new Guid("86634405-36a8-4727-93bd-97273e947361"), "Vega Station", "Gamma Wing" },
                    { new Guid("9ddf8528-35eb-433f-8486-29fc4123f4ff"), "Tau Outpost", "Eta Convoy" },
                    { new Guid("c8186cc3-573a-411b-b2d7-a5fd40b9beaf"), "Andromeda Port", "Zeta Patrol" },
                    { new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), "Sol System", "Alpha Fleet" },
                    { new Guid("e40fcb34-fda4-4f52-889b-996b0040a7ce"), "Centauri Reach", "Delta Fleet" }
                });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Class", "FleetId", "ImageUrl", "IsAvailable", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[,]
                {
                    { 1, "Interceptor", new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), "/images/vanguard.jpg", true, "Vanguard", 0, 1, 2225 },
                    { 2, "Fighter", new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), "/images/corsair.jpg", true, "Corsair", 1, 0, 2228 }
                });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Class", "FleetId", "ImageUrl", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { 3, "Corvette", new Guid("4241c74f-092c-4249-b731-954fb7658830"), "/images/harbinger.jpg", "Harbinger", 2, 2, 2215 });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Class", "FleetId", "ImageUrl", "IsAvailable", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { 4, "Frigate", new Guid("4241c74f-092c-4249-b731-954fb7658830"), "/images/aegis.jpg", true, "Aegis", 1, 3, 2230 });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Class", "FleetId", "ImageUrl", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { 5, "Destroyer", new Guid("86634405-36a8-4727-93bd-97273e947361"), "/images/leviathan.jpg", "Leviathan", 3, 4, 2240 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("1ad72291-5fa1-4744-9db8-19a382b269fd"));

            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("44dee55a-f48f-419f-884b-943355bbde32"));

            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("596dc552-0964-4298-baa7-34bee5b255b3"));

            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("6c6294c1-d329-4240-9620-d4bebed89fd3"));

            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("9ddf8528-35eb-433f-8486-29fc4123f4ff"));

            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("c8186cc3-573a-411b-b2d7-a5fd40b9beaf"));

            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("e40fcb34-fda4-4f52-889b-996b0040a7ce"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("4241c74f-092c-4249-b731-954fb7658830"));

            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("86634405-36a8-4727-93bd-97273e947361"));

            migrationBuilder.DeleteData(
                table: "Fleets",
                keyColumn: "Id",
                keyValue: new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"));

            migrationBuilder.AlterColumn<bool>(
                name: "IsAvailable",
                table: "Ships",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
