using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCentre.API.Migrations
{
    public partial class UpdateRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationName",
                table: "AspNetRoles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationName",
                table: "AspNetRoles");
        }
    }
}
