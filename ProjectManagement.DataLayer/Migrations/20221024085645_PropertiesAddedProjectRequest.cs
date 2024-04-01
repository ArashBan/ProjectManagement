using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.DataLayer.Migrations
{
    public partial class PropertiesAddedProjectRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPractical",
                table: "ProjectRequests");

            migrationBuilder.AddColumn<DateTime>(
                name: "ParentAcceptDate",
                table: "ProjectRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProjectType",
                table: "ProjectRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TeacherAcceptDate",
                table: "ProjectRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentAcceptDate",
                table: "ProjectRequests");

            migrationBuilder.DropColumn(
                name: "ProjectType",
                table: "ProjectRequests");

            migrationBuilder.DropColumn(
                name: "TeacherAcceptDate",
                table: "ProjectRequests");

            migrationBuilder.AddColumn<bool>(
                name: "IsPractical",
                table: "ProjectRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
