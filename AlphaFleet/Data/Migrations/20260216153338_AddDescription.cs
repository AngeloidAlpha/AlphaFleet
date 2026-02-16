using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "History",
                table: "Ships",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 1,
                column: "History",
                value: "The Vanguard was the first interceptor-class vessel produced by the Sol Shipyards in 2225. Originally designed for rapid reconnaissance missions, it quickly became the backbone of Alpha Fleet's patrol operations. Its lightweight frame and advanced sensor array made it ideal for early-warning deployments along the outer rim.");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 2,
                column: "History",
                value: "Commissioned in 2228, the Corsair was built to fill the gap between interceptors and corvettes. Armed with dual plasma cannons and reinforced hull plating, it earned its reputation during the Orion Skirmishes where a squadron of Corsairs held off an entire enemy flotilla for 72 hours.");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 3,
                column: "History",
                value: "The Harbinger is one of the oldest active vessels in the fleet, launched in 2215 from the Centauri Reach drydocks. It served as a testbed for experimental stealth technology and was instrumental in covert operations during the Vega Conflict. Currently decommissioned for a major refit of its propulsion systems.");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 4,
                column: "History",
                value: "The Aegis was designed as a defensive powerhouse, equipped with multi-layered shield generators and point-defense systems. Launched in 2230, it has served as the flagship escort for Beta Squadron, protecting capital ships during large-scale fleet engagements across the Orion Sector.");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: 5,
                column: "History",
                value: "The Leviathan is a destroyer of unmatched firepower, completed in 2240 at the classified Sirius Gate facility. Its main battery can cripple a space station in a single salvo. Only one was ever built due to the immense cost. Currently undergoing repairs after sustaining heavy damage in the Battle of Andromeda Port.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "History",
                table: "Ships");
        }
    }
}
