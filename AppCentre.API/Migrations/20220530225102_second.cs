using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCentre.API.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetApplications",
                columns: new[] { "ApplicationsID", "ApplicationsName", "ShortName" },
                values: new object[] { "59133643-5673-43cf-a497-183c7a5038a5", "Applications Centre", "AppCentre" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Grade", "LockoutEnabled", "LockoutEnd", "Matricule", "NN", "Nom", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Prenom", "SecurityStamp", "Service", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f9a351e2-bd5a-491d-9b24-b3c048df3935", 0, "9fb15b3e-26d8-43ac-9b8d-81770cb3682d", "Youcef_OULD_DJABALLAH@AppCentre.DRH", true, 15, false, null, "3K174", 400123, "Youcef", "Youcef_OULD_DJABALLAH@AppCentre.DRH", null, "Nzl2BjEDeWPAnh3TwojJ7kvDzoCX0aKQ7rC/vOjdG7s=", null, false, "OULD DJABALLAH", "2d6d0d14-1407-4b52-a201-cf3634ca4528", "16H\\", false, "Youcef_OULD_DJABALLAH" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ApplicationsID", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70f82a9c-ded4-4056-849d-29c0349bde2d", "59133643-5673-43cf-a497-183c7a5038a5", "af4fdbec-47ed-470e-99e4-a27a7d3bae5b", "Developer", "Developer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70f82a9c-ded4-4056-849d-29c0349bde2d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f9a351e2-bd5a-491d-9b24-b3c048df3935");

            migrationBuilder.DeleteData(
                table: "AspNetApplications",
                keyColumn: "ApplicationsID",
                keyValue: "59133643-5673-43cf-a497-183c7a5038a5");
        }
    }
}
