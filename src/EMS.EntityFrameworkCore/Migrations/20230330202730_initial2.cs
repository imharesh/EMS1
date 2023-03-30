using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "AppEmployees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "ShortBio",
                table: "AppDepartments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.CreateIndex(
                name: "IX_AppEmployees_DepartmentId",
                table: "AppEmployees",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppEmployees_AppDepartments_DepartmentId",
                table: "AppEmployees",
                column: "DepartmentId",
                principalTable: "AppDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppEmployees_AppDepartments_DepartmentId",
                table: "AppEmployees");

            migrationBuilder.DropIndex(
                name: "IX_AppEmployees_DepartmentId",
                table: "AppEmployees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AppEmployees");

            migrationBuilder.AlterColumn<string>(
                name: "ShortBio",
                table: "AppDepartments",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
