using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedata1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cff2c4ae-cc8f-4d94-b3d3-c2bc4e0cc849", "AQAAAAIAAYagAAAAEFsWA7tOBtS6zSxp77hvWhp3RnRo+IQ79Q4AUWRCI+Zr8VgyTzjsCpboN9mYJdiYFw==", "0961f3d9-ebca-4f24-bc69-d172540b8e6a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0be77b70-be1c-42f7-a93e-ddbf17d0ff9f", "AQAAAAIAAYagAAAAENnbw0FpkEPMGB0AB9fo98XGSN4nzR7kyJzJ3Xua/qgHmRKoiWWeQdo3OY1mzYQj3Q==", "cf784e2d-404d-47a4-b9a5-d22097aa0d1a" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 18, 12, 46, 28, 555, DateTimeKind.Local).AddTicks(3175));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 18, 12, 46, 28, 555, DateTimeKind.Local).AddTicks(3190));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc92c37f-8296-4b1a-b333-5b3e67ed42fe", "AQAAAAIAAYagAAAAEAx4YV9FHboISmf7fpj7jkglAs5FBkEzPQ7ZAI7l0Cy498JvsZ3m2DUj1yM1OP4qCg==", "cc8550fa-bc2a-476b-9e8c-8a024d304935" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d880b0b-9fc5-497a-97e9-d69af9267eb1", "AQAAAAIAAYagAAAAEKz0C6xRfxJNjT0jHbURIJ9nNigvev8sYpug/KRGuOlHxrbtGW6B/VnTBwZ8R/Buag==", "0b588118-485f-4533-a5e0-af16d475dcf6" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 18, 12, 44, 2, 159, DateTimeKind.Local).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 18, 12, 44, 2, 159, DateTimeKind.Local).AddTicks(1093));
        }
    }
}
