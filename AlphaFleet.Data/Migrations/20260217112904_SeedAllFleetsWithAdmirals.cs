using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlphaFleet.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAllFleetsWithAdmirals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admirals",
                columns: new[] { "Id", "Bio", "FirstName", "FleetId", "ImageUrl", "LastName", "Rank" },
                values: new object[,]
                {
                    { new Guid("4e8a1f6c-d293-47b5-a81e-9c5f0e7d2a38"), "Henrik Stålberg is a logistics genius who keeps the supply lines running no matter the circumstances. Under his command, Eta Convoy has never lost a single cargo shipment, earning him the nickname 'The Unbreakable Chain'.", "Henrik", new Guid("9ddf8528-35eb-433f-8486-29fc4123f4ff"), "/images/admirals/stalberg.jpg", "Stålberg", 0 },
                    { new Guid("6f1e4b8d-c5a2-49d7-b3f0-8e2d7a9c6b51"), "Fleet Admiral Mensah is a visionary who championed the construction of Laniakea Hub as a forward operating base. His bold expansionist strategy doubled the navy's operational range and opened new territories for exploration.", "Kofi", new Guid("6c6294c1-d329-4240-9620-d4bebed89fd3"), "/images/admirals/mensah.jpg", "Mensah", 3 },
                    { new Guid("a2d9c7e5-1b84-4f63-90ae-6d8b3f5c4e17"), "Vice Admiral Sharma is a decorated combat pilot who flew over 300 sorties before taking command of Theta Squadron. Her hands-on leadership style and refusal to send her crews anywhere she wouldn't go herself have earned her fierce loyalty.", "Priya", new Guid("596dc552-0964-4298-baa7-34bee5b255b3"), "/images/admirals/sharma.jpg", "Sharma", 1 },
                    { new Guid("b7c3d8a1-5e4f-4a92-8d16-7f3b2c9e1d04"), "Nadia Reyes is a former intelligence officer who transitioned to fleet command after uncovering a pirate syndicate in the Andromeda corridor. Her sharp instincts and network of informants make Zeta Patrol the most well-informed unit in the navy.", "Nadia", new Guid("c8186cc3-573a-411b-b2d7-a5fd40b9beaf"), "/images/admirals/reyes.jpg", "Reyes", 2 },
                    { new Guid("c8d3a5f2-7e19-4b06-a4d8-1f9e6c3b5d72"), "Admiral Petrov commands Kappa Division from the remote Orpheus Station, where he oversees deep-space patrol and border defense. A master of asymmetric warfare, she has repelled incursions from forces ten times her fleet's size.", "Svetlana", new Guid("1ad72291-5fa1-4744-9db8-19a382b269fd"), "/images/admirals/petrov.jpg", "Petrov", 2 }
                });

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("3b12f1b5-981a-4d72-804b-ae15c78264ab"),
                column: "ImageUrl",
                value: "/images/ships/corsair.jpg");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("9c4e6f2a-7d38-4e5b-b120-df6a41c8e9c7"),
                column: "ImageUrl",
                value: "/images/ships/harbinger.jpg");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("d5a83f4e-2b17-49c6-a8e3-7f1d9b05c42e"),
                column: "ImageUrl",
                value: "/images/ships/aegis.jpg");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("e72b4a19-6c5d-4f83-91a2-8d3e0b7fc56a"),
                column: "ImageUrl",
                value: "/images/ships/leviathan.jpg");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                column: "ImageUrl",
                value: "/images/ships/vanguard.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admirals",
                keyColumn: "Id",
                keyValue: new Guid("4e8a1f6c-d293-47b5-a81e-9c5f0e7d2a38"));

            migrationBuilder.DeleteData(
                table: "Admirals",
                keyColumn: "Id",
                keyValue: new Guid("6f1e4b8d-c5a2-49d7-b3f0-8e2d7a9c6b51"));

            migrationBuilder.DeleteData(
                table: "Admirals",
                keyColumn: "Id",
                keyValue: new Guid("a2d9c7e5-1b84-4f63-90ae-6d8b3f5c4e17"));

            migrationBuilder.DeleteData(
                table: "Admirals",
                keyColumn: "Id",
                keyValue: new Guid("b7c3d8a1-5e4f-4a92-8d16-7f3b2c9e1d04"));

            migrationBuilder.DeleteData(
                table: "Admirals",
                keyColumn: "Id",
                keyValue: new Guid("c8d3a5f2-7e19-4b06-a4d8-1f9e6c3b5d72"));

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("3b12f1b5-981a-4d72-804b-ae15c78264ab"),
                column: "ImageUrl",
                value: "/images/corsair.jpg");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("9c4e6f2a-7d38-4e5b-b120-df6a41c8e9c7"),
                column: "ImageUrl",
                value: "/images/harbinger.jpg");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("d5a83f4e-2b17-49c6-a8e3-7f1d9b05c42e"),
                column: "ImageUrl",
                value: "/images/aegis.jpg");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("e72b4a19-6c5d-4f83-91a2-8d3e0b7fc56a"),
                column: "ImageUrl",
                value: "/images/leviathan.jpg");

            migrationBuilder.UpdateData(
                table: "Ships",
                keyColumn: "Id",
                keyValue: new Guid("f47ac10b-58cc-4372-a567-0e02b2c3d479"),
                column: "ImageUrl",
                value: "/images/vanguard.jpg");
        }
    }
}
