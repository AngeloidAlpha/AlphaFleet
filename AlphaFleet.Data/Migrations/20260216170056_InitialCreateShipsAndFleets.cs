using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlphaFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateShipsAndFleets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fleets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fleets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipHullClass = table.Column<int>(type: "int", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    ShipProductionYear = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    FleetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_Fleets_FleetId",
                        column: x => x.FleetId,
                        principalTable: "Fleets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "Class", "FleetId", "History", "ImageUrl", "IsAvailable", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { new Guid("3b12f1b5-981a-4d72-804b-ae15c78264ab"), "Fighter", new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), "Commissioned in 2228, the Corsair was built to fill the gap between interceptors and corvettes. Armed with dual plasma cannons and reinforced hull plating, it earned its reputation during the Orion Skirmishes where a squadron of Corsairs held off an entire enemy flotilla for 72 hours.", "/images/corsair.jpg", true, "Corsair", 1, 0, 2228 });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Class", "FleetId", "History", "ImageUrl", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { new Guid("9c4e6f2a-7d38-4e5b-b120-df6a41c8e9c7"), "Corvette", new Guid("4241c74f-092c-4249-b731-954fb7658830"), "The Harbinger is one of the oldest active vessels in the fleet, launched in 2215 from the Centauri Reach drydocks. It served as a testbed for experimental stealth technology and was instrumental in covert operations during the Vega Conflict. Currently decommissioned for a major refit of its propulsion systems.", "/images/harbinger.jpg", "Harbinger", 2, 2, 2215 });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Class", "FleetId", "History", "ImageUrl", "IsAvailable", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { new Guid("d5a83f4e-2b17-49c6-a8e3-7f1d9b05c42e"), "Frigate", new Guid("4241c74f-092c-4249-b731-954fb7658830"), "The Aegis was designed as a defensive powerhouse, equipped with multi-layered shield generators and point-defense systems. Launched in 2230, it has served as the flagship escort for Beta Squadron, protecting capital ships during large-scale fleet engagements across the Orion Sector.", "/images/aegis.jpg", true, "Aegis", 1, 3, 2230 });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Class", "FleetId", "History", "ImageUrl", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { new Guid("e72b4a19-6c5d-4f83-91a2-8d3e0b7fc56a"), "Destroyer", new Guid("86634405-36a8-4727-93bd-97273e947361"), "The Leviathan is a destroyer of unmatched firepower, completed in 2240 at the classified Sirius Gate facility. Its main battery can cripple a space station in a single salvo. Only one was ever built due to the immense cost. Currently undergoing repairs after sustaining heavy damage in the Battle of Andromeda Port.", "/images/leviathan.jpg", "Leviathan", 3, 4, 2240 });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Class", "FleetId", "History", "ImageUrl", "IsAvailable", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), "Interceptor", new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), "The Vanguard was the first interceptor-class vessel produced by the Sol Shipyards in 2225. Originally designed for rapid reconnaissance missions, it quickly became the backbone of Alpha Fleet's patrol operations. Its lightweight frame and advanced sensor array made it ideal for early-warning deployments along the outer rim.", "/images/vanguard.jpg", true, "Vanguard", 0, 1, 2225 });

            migrationBuilder.CreateIndex(
                name: "IX_Ships_FleetId",
                table: "Ships",
                column: "FleetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "Fleets");
        }
    }
}
