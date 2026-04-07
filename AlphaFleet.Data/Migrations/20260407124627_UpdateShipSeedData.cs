using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlphaFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateShipSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("3b12f1b5-981a-4d72-804b-ae15c78264ab"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("9c4e6f2a-7d38-4e5b-b120-df6a41c8e9c7"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("d5a83f4e-2b17-49c6-a8e3-7f1d9b05c42e"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("e72b4a19-6c5d-4f83-91a2-8d3e0b7fc56a"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"));

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Attack", "Class", "Defense", "FleetId", "Health", "History", "ImageUrl", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { new Guid("2a6f1b8e-4d9c-4e3f-a5b2-c1d7e8f9a3b5"), 56, "Corvette", 6, new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), 280, "The Harbinger is one of the oldest active vessels in the fleet, launched in 2215 from the Centauri Reach drydocks. It served as a testbed for experimental stealth technology and was instrumental in covert operations during the Vega Conflict.", "/images/ships/default.png", "Harbinger", 2, 2, 2215 });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Attack", "Class", "Defense", "FleetId", "Health", "History", "ImageUrl", "IsAvailable", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[,]
                {
                    { new Guid("3e9a4c7b-8f2d-4a56-b1c9-7d5e3a2f6b8c"), 24, "Interceptor", 2, new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), 120, "The Vanguard was the first interceptor-class vessel produced by the Sol Shipyards in 2225. Originally designed for rapid reconnaissance missions, it quickly became the backbone of Alpha Fleet's patrol operations. Its lightweight frame and advanced sensor array made it ideal for early-warning deployments along the outer rim.", "/images/ships/default.png", true, "Vanguard", 1, 1, 2225 },
                    { new Guid("6c9e2d4a-7f1b-4c5a-b8e3-1d9a6f2c5b8e"), 9216, "AircraftCarrier", 922, new Guid("4241c74f-092c-4249-b731-954fb7658830"), 46080, "The Colossus is the largest vessel ever constructed by humanity. Its cavernous flight deck houses over three hundred fighters and interceptors. It was built in secret over fifteen years at a classified Kuiper Belt facility, and its maiden deployment ended the Andromeda War in a single engagement.", "/images/ships/default.png", true, "Colossus", 3, 9, 2255 }
                });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Attack", "Class", "Defense", "FleetId", "Health", "History", "ImageUrl", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { new Guid("7f4a9c2d-e3b1-4a7f-9d5c-2e8a4b6f1c9e"), 288, "Destroyer", 29, new Guid("4241c74f-092c-4249-b731-954fb7658830"), 1440, "The Leviathan is a destroyer of unmatched firepower, completed in 2240 at the classified Sirius Gate facility. Its main battery can cripple a space station in a single salvo. Only one was ever built due to the immense cost.", "/images/ships/default.png", "Leviathan", 3, 4, 2240 });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Attack", "Class", "Defense", "FleetId", "Health", "History", "ImageUrl", "IsAvailable", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[,]
                {
                    { new Guid("9c5b3d7e-6a1f-4c8a-b3d4-e9f2a5c6b8d1"), 88, "Frigate", 9, new Guid("4241c74f-092c-4249-b731-954fb7658830"), 440, "The Aegis was designed as a defensive powerhouse, equipped with multi-layered shield generators and point-defence systems. Launched in 2230, it has served as the flagship escort for Beta Squadron across the Orion Sector.", "/images/ships/default.png", true, "Aegis", 0, 3, 2230 },
                    { new Guid("a1d4f8c3-5e2b-4d9a-8f1c-6a3e7b2f5d8a"), 384, "Cruiser", 38, new Guid("86634405-36a8-4727-93bd-97273e947361"), 1920, "Commissioned in 2228, the Corsair was built to fill the gap between destroyers and heavy cruisers. Armed with quad plasma cannons and reinforced hull plating, it earned its reputation during the Orion Skirmishes where it held off an enemy flotilla for 72 hours.", "/images/ships/default.png", true, "Corsair", 1, 5, 2228 },
                    { new Guid("b4f7d1c8-9a3e-4d6b-a2f5-7e1c4b8d3a6f"), 3072, "CapitalShip", 307, new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), 15360, "The Sovereign is the command vessel of the First Fleet, renowned across all sectors as a symbol of Sol's naval dominance. Its bridge houses a crew of four hundred officers, and its presence alone has ended conflicts before the first shot was fired.", "/images/ships/default.png", true, "Sovereign", 1, 8, 2250 },
                    { new Guid("d2b6f9a7-4c8e-4b3f-a1d5-9e7c2a5f8b1d"), 704, "HeavyCruiser", 70, new Guid("86634405-36a8-4727-93bd-97273e947361"), 3520, "The Ironclad lives up to its name. Its hull is layered with seven centimetres of ablative armour plating, making it near impervious to light weapons fire. It has served as a forward assault vessel in every major fleet engagement since its commissioning.", "/images/ships/default.png", true, "Ironclad", 0, 6, 2238 },
                    { new Guid("e8c3a5b9-6d2f-4a1e-9c7d-3f8b5a2e6c9a"), 1792, "Battlecruiser", 179, new Guid("86634405-36a8-4727-93bd-97273e947361"), 8960, "The Nemesis was conceived as a warship that could hunt down and destroy anything short of a capital ship. Its long-range siege cannons can engage targets at distances that render enemy return fire nearly impossible.", "/images/ships/default.png", true, "Nemesis", 2, 7, 2244 },
                    { new Guid("f7d4e8a2-5c19-4b7e-9f21-a8c3b6d1e9f4"), 11, "Fighter", 1, new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), 55, "The Sparrow is the most mass-produced fighter in the Sol Defence Force. Cheap, fast, and expendable, entire wings of Sparrows are launched ahead of larger vessels to screen against incoming missile volleys and probe enemy formations.", "/images/ships/default.png", true, "Sparrow", 0, 0, 2235 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("2a6f1b8e-4d9c-4e3f-a5b2-c1d7e8f9a3b5"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("3e9a4c7b-8f2d-4a56-b1c9-7d5e3a2f6b8c"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("6c9e2d4a-7f1b-4c5a-b8e3-1d9a6f2c5b8e"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("7f4a9c2d-e3b1-4a7f-9d5c-2e8a4b6f1c9e"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("9c5b3d7e-6a1f-4c8a-b3d4-e9f2a5c6b8d1"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("a1d4f8c3-5e2b-4d9a-8f1c-6a3e7b2f5d8a"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("b4f7d1c8-9a3e-4d6b-a2f5-7e1c4b8d3a6f"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("d2b6f9a7-4c8e-4b3f-a1d5-9e7c2a5f8b1d"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("e8c3a5b9-6d2f-4a1e-9c7d-3f8b5a2e6c9a"));

            migrationBuilder.DeleteData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("f7d4e8a2-5c19-4b7e-9f21-a8c3b6d1e9f4"));

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Attack", "Class", "Defense", "FleetId", "Health", "History", "ImageUrl", "IsAvailable", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { new Guid("3b12f1b5-981a-4d72-804b-ae15c78264ab"), 10, "Fighter", 1, new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), 50, "Commissioned in 2228, the Corsair was built to fill the gap between interceptors and corvettes. Armed with dual plasma cannons and reinforced hull plating, it earned its reputation during the Orion Skirmishes where a squadron of Corsairs held off an entire enemy flotilla for 72 hours.", "/images/ships/corsair.jpg", true, "Corsair", 1, 0, 2228 });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Attack", "Class", "Defense", "FleetId", "Health", "History", "ImageUrl", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { new Guid("9c4e6f2a-7d38-4e5b-b120-df6a41c8e9c7"), 10, "Corvette", 1, new Guid("4241c74f-092c-4249-b731-954fb7658830"), 50, "The Harbinger is one of the oldest active vessels in the fleet, launched in 2215 from the Centauri Reach drydocks. It served as a testbed for experimental stealth technology and was instrumental in covert operations during the Vega Conflict. Currently decommissioned for a major refit of its propulsion systems.", "/images/ships/harbinger.jpg", "Harbinger", 2, 2, 2215 });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Attack", "Class", "Defense", "FleetId", "Health", "History", "ImageUrl", "IsAvailable", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { new Guid("d5a83f4e-2b17-49c6-a8e3-7f1d9b05c42e"), 10, "Frigate", 1, new Guid("4241c74f-092c-4249-b731-954fb7658830"), 50, "The Aegis was designed as a defensive powerhouse, equipped with multi-layered shield generators and point-defense systems. Launched in 2230, it has served as the flagship escort for Beta Squadron, protecting capital ships during large-scale fleet engagements across the Orion Sector.", "/images/ships/aegis.jpg", true, "Aegis", 1, 3, 2230 });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Attack", "Class", "Defense", "FleetId", "Health", "History", "ImageUrl", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { new Guid("e72b4a19-6c5d-4f83-91a2-8d3e0b7fc56a"), 10, "Destroyer", 1, new Guid("86634405-36a8-4727-93bd-97273e947361"), 50, "The Leviathan is a destroyer of unmatched firepower, completed in 2240 at the classified Sirius Gate facility. Its main battery can cripple a space station in a single salvo. Only one was ever built due to the immense cost. Currently undergoing repairs after sustaining heavy damage in the Battle of Andromeda Port.", "/images/ships/leviathan.jpg", "Leviathan", 3, 4, 2240 });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "Attack", "Class", "Defense", "FleetId", "Health", "History", "ImageUrl", "IsAvailable", "Name", "Rarity", "ShipHullClass", "ShipProductionYear" },
                values: new object[] { new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"), 10, "Interceptor", 1, new Guid("c8b02d34-76f8-4dbd-942e-2d680d5b84ef"), 50, "The Vanguard was the first interceptor-class vessel produced by the Sol Shipyards in 2225. Originally designed for rapid reconnaissance missions, it quickly became the backbone of Alpha Fleet's patrol operations. Its lightweight frame and advanced sensor array made it ideal for early-warning deployments along the outer rim.", "/images/ships/vanguard.jpg", true, "Vanguard", 0, 1, 2225 });
        }
    }
}
