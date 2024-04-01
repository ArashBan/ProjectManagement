using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.DataLayer.Migrations
{
    public partial class ProjectDefenseAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Roles_RoleId",
                table: "Permissions");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teachers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Students",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ProjectRequests",
                newName: "ProjectRequests",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "ProjectProgresses",
                newName: "ProjectProgresses",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Problems",
                newName: "Problems",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Permissions",
                newName: "Permissions",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notifications",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "News",
                newName: "News",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "InternshipRequests",
                newName: "InternshipRequests",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "InternshipReports",
                newName: "InternshipReports",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "Enrollments",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Courses",
                newSchema: "dbo");

            migrationBuilder.CreateTable(
                name: "ProjectDefenseRequests",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Situation = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDefenseRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectDefenseRequests_ProjectRequests_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "dbo",
                        principalTable: "ProjectRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectDefenseRequests_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "dbo",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectDefenseRequests_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "dbo",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDefenseRequests_ProjectId",
                schema: "dbo",
                table: "ProjectDefenseRequests",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDefenseRequests_StudentId",
                schema: "dbo",
                table: "ProjectDefenseRequests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDefenseRequests_TeacherId",
                schema: "dbo",
                table: "ProjectDefenseRequests",
                column: "TeacherId");

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

            migrationBuilder.DropTable(
                name: "ProjectDefenseRequests",
                schema: "dbo");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "dbo",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Teachers",
                schema: "dbo",
                newName: "Teachers");

            migrationBuilder.RenameTable(
                name: "Students",
                schema: "dbo",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "dbo",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "ProjectRequests",
                schema: "dbo",
                newName: "ProjectRequests");

            migrationBuilder.RenameTable(
                name: "ProjectProgresses",
                schema: "dbo",
                newName: "ProjectProgresses");

            migrationBuilder.RenameTable(
                name: "Problems",
                schema: "dbo",
                newName: "Problems");

            migrationBuilder.RenameTable(
                name: "Permissions",
                schema: "dbo",
                newName: "Permissions");

            migrationBuilder.RenameTable(
                name: "Notifications",
                schema: "dbo",
                newName: "Notifications");

            migrationBuilder.RenameTable(
                name: "News",
                schema: "dbo",
                newName: "News");

            migrationBuilder.RenameTable(
                name: "InternshipRequests",
                schema: "dbo",
                newName: "InternshipRequests");

            migrationBuilder.RenameTable(
                name: "InternshipReports",
                schema: "dbo",
                newName: "InternshipReports");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                schema: "dbo",
                newName: "Enrollments");

            migrationBuilder.RenameTable(
                name: "Courses",
                schema: "dbo",
                newName: "Courses");

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
