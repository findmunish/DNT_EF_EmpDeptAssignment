using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfAssignment.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Employees",
                type: "varchar(512)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "VARBINARY(MAX)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Employees",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(512)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Name",
                table: "Departments",
                type: "VARBINARY(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)");
        }
    }
}
