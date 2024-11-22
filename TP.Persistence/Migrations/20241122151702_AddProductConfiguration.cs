using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddProductConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedBy",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ManufacturePhone",
                table: "Products",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ManufactureEmail",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "IsAvailable", "LastModifiedBy", "LastModifiedDate", "ManufactureEmail", "ManufacturePhone", "Name", "ProduceDate" },
                values: new object[,]
                {
                    { 1, "a88fe82a-c55a-42ca-b390-ad5337bdb23b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "maedeh.shahcheraghi1384@gmail.com", "09925772866", "Product 1", new DateTime(2024, 11, 22, 18, 47, 2, 176, DateTimeKind.Local).AddTicks(7064) },
                    { 2, "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "maedeh.shahcheraghi2005@gmail.com", "09925772867", "Product 2", new DateTime(2024, 11, 22, 18, 47, 2, 176, DateTimeKind.Local).AddTicks(7084) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufactureEmail_ProduceDate",
                table: "Products",
                columns: new[] { "ManufactureEmail", "ProduceDate" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedBy",
                table: "Products",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedBy",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ManufactureEmail_ProduceDate",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ManufacturePhone",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "ManufactureEmail",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c61ddc50-5690-4894-98d7-c652d15948a2", "AQAAAAIAAYagAAAAEAy/XpRIq97BufhhwB0g6hLWG4EaZFoTEPkldbKG4MmxrxYbQ1ncBb4dXM0BOefJ5w==", "b7cd1247-f171-4a29-9400-46084ef33a3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa58a1ee-ddd7-4bec-8f1c-59e3bd47f5e2", "AQAAAAIAAYagAAAAEASXVtAIIgOWuZvp6R6M3goJEirqEHonFkmtG+2kTVqbsQ2hbjExO5IEVqJxiY9BFQ==", "641e9891-cba9-4aad-b686-674d502ec402" });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedBy",
                table: "Products",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
