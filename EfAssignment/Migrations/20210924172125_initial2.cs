using Microsoft.EntityFrameworkCore.Migrations;

namespace EfAssignment.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Employees",
                type: "varchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(512)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Employees",
                type: "varchar(512)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(250)");
        }
    }
}
