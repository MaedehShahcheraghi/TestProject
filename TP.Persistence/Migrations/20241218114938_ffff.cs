using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ffff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9446909-caa1-4e19-9980-e1c8d96d12e7", "AQAAAAIAAYagAAAAEKlS2gy4zhksfZ+GcVTTcmg1IQICZzS2oWKMNuN/dgbe3OXZgt3T4KHwsFREfrM4gA==", "450bb883-36db-4a70-9385-aa44cece5f2b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b8ba900-7d36-4e72-af12-e269aa8b45d6", "AQAAAAIAAYagAAAAEBHU9hm4xhJnhrri8Ww5BjZagaZx8i/iq0OcvmkMS3NNZ1zYW242gHflJYGZwUcJwQ==", "4851bfc6-8bc5-4617-8275-1d3dee5a246a" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 18, 15, 19, 37, 718, DateTimeKind.Local).AddTicks(874));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 18, 15, 19, 37, 718, DateTimeKind.Local).AddTicks(888));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
