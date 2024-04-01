using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.DataLayer.Migrations
{
    public partial class TeacherSelfRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Field",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Semester",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_ParentId",
                table: "Teachers",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Teachers_ParentId",
                table: "Teachers",
                column: "ParentId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Teachers_ParentId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_ParentId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "Field",
                table: "Teachers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }
    }
}
