using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addguestrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationUserId", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d78a6151-9456-4433-93fa-0b1170ee9f8d", null, null, "Guest", "GUEST" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac6fdd6e-99c6-4da3-9402-f9f8286c911e", "AQAAAAIAAYagAAAAEBREgWlcY+REfOmqLGnqGuFanzxwK0u62C4OhSBV/cqR5O4CuD/OWArfIFWLy+B+4w==", "8f15776e-ecfa-4d7a-9a42-c3aa230642a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73e5a0af-0c71-4a5c-80d5-517f3a185345", "AQAAAAIAAYagAAAAEGagoLPU9gM5RRzOpUfN2hTuaKfsHuB+jAYD+aloiOxAOGaaGR1/f0YCB30KRBzx2g==", "1243d85c-b5e5-49e8-8a40-461cd96e0481" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 26, 11, 56, 26, 586, DateTimeKind.Local).AddTicks(2456));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 26, 11, 56, 26, 586, DateTimeKind.Local).AddTicks(2470));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d78a6151-9456-4433-93fa-0b1170ee9f8d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d9603f9-d0b5-4bb2-9a02-b9311d641e14", "AQAAAAIAAYagAAAAEDz9AHQTdXfRAgPJwCWBh/51KAGoM6ISWMESAhlXJ2mN9RssFBM2Kcb8ZwbUqLQsZg==", "bdff8e51-b6fc-42d3-b9a3-2ffe9718a894" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed9e04ab-c89e-49e2-9a59-c22a1d765541", "AQAAAAIAAYagAAAAEJSAMz1S5yNA3XbxKzcCXbILaMqphd3JMeDWDqSCSFWbMXWDGWbU+UbTLTYkrrJCCA==", "2e528668-7bf4-4acd-b411-101f5db4d74b" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 25, 15, 14, 31, 376, DateTimeKind.Local).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 25, 15, 14, 31, 376, DateTimeKind.Local).AddTicks(9504));
        }
    }
}
