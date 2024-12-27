using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class aaaaddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dc848b8-b860-4e3d-b8eb-902ae7dd53ee", "AQAAAAIAAYagAAAAEOoN88bY3FTaTVlAE2593Vbsba0tAn2XNinOpT+ztoAaVHqPJYVn8zbf5pdQro+ZiQ==", "449b9a0c-98c3-4fab-8b67-278b001351f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dce17038-e9b1-4851-b785-02c7fb57e69a", "AQAAAAIAAYagAAAAEMVCfExJ6oM5iA1OTpJxLDlFk6T6SlzYmEbqKE2ZXDIOjtVmpmoHD14/h+XNwfytWw==", "1c8531f1-b02e-410e-a3cd-fb18bfb97dd1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 26, 16, 53, 48, 724, DateTimeKind.Local).AddTicks(6845));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 26, 16, 53, 48, 724, DateTimeKind.Local).AddTicks(6871));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
