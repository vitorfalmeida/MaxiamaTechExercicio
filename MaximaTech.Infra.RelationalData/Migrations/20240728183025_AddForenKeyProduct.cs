using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaximaTech.Infra.RelationalData.Migrations
{
    public partial class AddForenKeyProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Departments",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DepartmentId",
                table: "Products",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Departments_DepartmentId",
                table: "Products",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Departments_DepartmentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DepartmentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "Code",
                table: "Departments",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
