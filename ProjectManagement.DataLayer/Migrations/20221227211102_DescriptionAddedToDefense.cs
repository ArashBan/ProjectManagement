using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.DataLayer.Migrations
{
    public partial class DescriptionAddedToDefense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "ProjectDefenseRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 28, 0, 41, 2, 728, DateTimeKind.Local).AddTicks(8995));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 28, 0, 41, 2, 728, DateTimeKind.Local).AddTicks(9020));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 28, 0, 41, 2, 730, DateTimeKind.Local).AddTicks(7966));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 28, 0, 41, 2, 730, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                schema: "dbo",
                table: "Permissions",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                schema: "dbo",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "dbo",
                table: "ProjectDefenseRequests");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 17, 59, 10, 838, DateTimeKind.Local).AddTicks(8237));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 17, 59, 10, 838, DateTimeKind.Local).AddTicks(8266));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 17, 59, 10, 840, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 12, 27, 17, 59, 10, 840, DateTimeKind.Local).AddTicks(7664));

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                schema: "dbo",
                table: "Permissions",
                column: "RoleId",
                principalSchema: "dbo",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
