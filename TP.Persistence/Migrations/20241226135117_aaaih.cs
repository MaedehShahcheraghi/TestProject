using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class aaaih : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_AspNetRoles_RoleId",
                table: "RolePermission");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermission_Permission_PermssionId",
                table: "RolePermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RolePermission",
                table: "RolePermission");

            migrationBuilder.RenameTable(
                name: "RolePermission",
                newName: "rolePermissions");

            migrationBuilder.RenameIndex(
                name: "IX_RolePermission_PermssionId",
                table: "rolePermissions",
                newName: "IX_rolePermissions_PermssionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rolePermissions",
                table: "rolePermissions",
                columns: new[] { "RoleId", "PermssionId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80d5b3db-6a01-4dcb-98d0-23f4d5e36b41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35f047d9-274a-4b11-a7be-70d47ee29ea2", "AQAAAAIAAYagAAAAEKNr1OkIcLiRQaFA/6Hw/GdOeoauNVIAU77LQE8GTla11ZA7t0owY+e6zdr3sfMJ/Q==", "3179442a-9f02-4d83-b588-31b658818661" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a88fe82a-c55a-42ca-b390-ad5337bdb23b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b833bd49-273f-4de7-b4b4-722418c2b75d", "AQAAAAIAAYagAAAAEPY/7IuRFGggzilDaeZoubIHgWVPOnmW07q5MTvdAshF1DVH14UT/PZOQSZuicmJfg==", "d013c434-ac7c-4f5a-bfa0-6222543293d8" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 26, 17, 21, 16, 864, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProduceDate",
                value: new DateTime(2024, 12, 26, 17, 21, 16, 864, DateTimeKind.Local).AddTicks(8286));

            migrationBuilder.AddForeignKey(
                name: "FK_rolePermissions_AspNetRoles_RoleId",
                table: "rolePermissions",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rolePermissions_Permission_PermssionId",
                table: "rolePermissions",
                column: "PermssionId",
                principalTable: "Permission",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rolePermissions_AspNetRoles_RoleId",
                table: "rolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_rolePermissions_Permission_PermssionId",
                table: "rolePermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rolePermissions",
                table: "rolePermissions");

            migrationBuilder.RenameTable(
                name: "rolePermissions",
                newName: "RolePermission");

            migrationBuilder.RenameIndex(
                name: "IX_rolePermissions_PermssionId",
                table: "RolePermission",
                newName: "IX_RolePermission_PermssionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RolePermission",
                table: "RolePermission",
                columns: new[] { "RoleId", "PermssionId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_AspNetRoles_RoleId",
                table: "RolePermission",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermission_Permission_PermssionId",
                table: "RolePermission",
                column: "PermssionId",
                principalTable: "Permission",
                principalColumn: "PermissionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
