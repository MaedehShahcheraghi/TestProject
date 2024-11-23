using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editdata1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "127f72c6-d3cf-4a1a-aefa-e4135021a544", "AQAAAAIAAYagAAAAEH7yeHDbZz+Es2NSld/uOAbR2ilCH+Jj43i6UmR3RV48N9v4KtAwupdMlcvKezP0yg==", "01c359fd-8132-458d-aae2-dde978977dba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "588e2d84-7153-464b-b651-bf0fbc4124be", "AQAAAAIAAYagAAAAEIOwOyb/KDiyIl/GzL63HAqRL8b3Mpf5cunymCcc9pCeBL5spmmOFBpUoDIDWJVQSQ==", "99d0cdd5-0a9a-4f68-a9c1-033bbfb66e45" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProduceDate",
                value: new DateTime(2024, 11, 22, 23, 56, 35, 407, DateTimeKind.Local).AddTicks(5112));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProduceDate",
                value: new DateTime(2024, 11, 22, 23, 56, 35, 407, DateTimeKind.Local).AddTicks(5128));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07f4a94d-17c3-4cd2-9b52-20dc0a59532b", "AQAAAAIAAYagAAAAELMay2qkK642KRBgdUUfWDo9XSa1Ue98Ojx1/XaFP95VPWB+FwV1zYdPWuuOburVdQ==", "dba01bd8-2ad2-49c2-9ca2-96cbbc682cd7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f316c64c-9ee1-4e52-8179-8a9b95d7699e", "AQAAAAIAAYagAAAAEEVwv29VVQXc16V5EWJTJ0R3IvzduZO2IW03YSo9HMDLEGTG/FjUdIeJZeWWaId37w==", "72742f41-9593-401d-ab42-ce886bbfb476" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProduceDate",
                value: new DateTime(2024, 11, 22, 18, 47, 2, 176, DateTimeKind.Local).AddTicks(7064));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProduceDate",
                value: new DateTime(2024, 11, 22, 18, 47, 2, 176, DateTimeKind.Local).AddTicks(7084));
        }
    }
}
