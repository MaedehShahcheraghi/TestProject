using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
