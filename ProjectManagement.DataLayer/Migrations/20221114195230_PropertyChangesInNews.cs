using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.DataLayer.Migrations
{
    public partial class PropertyChangesInNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "IsImportant",
                table: "News");

            migrationBuilder.AddColumn<int>(
                name: "Importance",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 11, 14, 23, 22, 30, 224, DateTimeKind.Local).AddTicks(6814));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 11, 14, 23, 22, 30, 224, DateTimeKind.Local).AddTicks(6839));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 11, 14, 23, 22, 30, 226, DateTimeKind.Local).AddTicks(2739));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 11, 14, 23, 22, 30, 226, DateTimeKind.Local).AddTicks(2754));

            migrationBuilder.CreateIndex(
                name: "IX_News_TeacherId",
                table: "News",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Teachers_TeacherId",
                table: "News",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Teachers_TeacherId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_News_TeacherId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Importance",
                table: "News");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "News");

            migrationBuilder.AddColumn<bool>(
                name: "IsImportant",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 11, 12, 22, 24, 25, 798, DateTimeKind.Local).AddTicks(4376));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 11, 12, 22, 24, 25, 798, DateTimeKind.Local).AddTicks(4421));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2022, 11, 12, 22, 24, 25, 800, DateTimeKind.Local).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2022, 11, 12, 22, 24, 25, 800, DateTimeKind.Local).AddTicks(3019));

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
